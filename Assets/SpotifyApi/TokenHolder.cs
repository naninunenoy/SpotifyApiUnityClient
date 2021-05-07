using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using n5y.SpotifyApi.Models;
using UnityEngine;

namespace n5y.SpotifyApi {
    public class TokenHolder : MonoBehaviour, ITokenProvider {
        // tokenの期限が1時間固定なので55分ごとに refresh を行う
        static readonly TimeSpan tokenRefreshInterval = TimeSpan.FromMinutes(55);
        static readonly object lockObj = new object();
        static TokenHolder instance;
        TokenModel token;
        string refreshToken;

        public TokenModel Token {
            get {
                lock (lockObj) {
                    return instance.token;
                }
            }
        }
        public void SetFirstToken(TokenModel firstToken) {
            lock (lockObj) {
                // RefreshToken があるのは最初に取得される TokenModel のみ
                instance.refreshToken = firstToken.RefreshToken;
                instance.token = firstToken;
            }
        }

        public static TokenHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (lockObj) {
                        instance = (TokenHolder)FindObjectOfType(typeof(TokenHolder));
                    }

                    if (instance == null)
                    {
                        Debug.LogWarning(typeof(TokenHolder) + "is nothing");
                    }
                }

                lock (lockObj) {
                    return instance;
                }
            }
        }

        void Awake() {
            if (CheckInstance()) {
                DontDestroyOnLoad(gameObject);
                var ct = this.GetCancellationTokenOnDestroy();
                UniTaskAsyncEnumerable
                    .Interval(tokenRefreshInterval)
                    .Select(_ => {
                        lock (lockObj) {
                            return instance.refreshToken;
                        }
                    })
                    .SelectAwait(refresh => Api.RefreshTokenAsync(refresh, Environment.ClientId, Environment.ClientSecret, ct))
                    .ForEachAsync(newToken => {
                        lock (lockObj) {
                            instance.token = newToken;
                        }
                    }, ct);
            }
        }

        bool CheckInstance()
        {
            if (instance == null)
            {
                lock (lockObj) {
                    instance = this;
                }
                return true;
            }
            if (Instance == this)
            {
                return true;
            }
            Destroy(gameObject);
            return false;
        }
    }
}
