using System;
using Cysharp.Threading.Tasks;
using SpotifyApi.Models;
using UniRx;
using UnityEngine;

namespace SpotifyApi {
    public class TokenHolder : MonoBehaviour, ITokenProvider {
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

        void Awake()
        {
            if (CheckInstance())
            {
                DontDestroyOnLoad(gameObject);
                // tokenの期限が1時間なので55分ごとにrefreshを行う
                Observable
                    .Interval(TimeSpan.FromMinutes(55), Scheduler.ThreadPool)
                    .ObserveOnMainThread()
                    .Subscribe(async _ => {
                        string refresh;
                        lock (lockObj) {
                            refresh = instance.refreshToken;
                        }
                        var newToken = await Api.RefreshTokenAsync(refresh, Environment.ClientId,
                            Environment.ClientSecret, this.GetCancellationTokenOnDestroy());
                        lock (lockObj) {
                            instance.token = newToken;
                        }
                    })
                    .AddTo(this);
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
