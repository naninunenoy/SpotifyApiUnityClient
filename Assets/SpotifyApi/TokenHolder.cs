using SpotifyApi.Models;
using UnityEngine;

namespace SpotifyApi {
    public class TokenHolder : MonoBehaviour, ITokenProvider {
        static TokenHolder instance;
        TokenModel token;
        public TokenModel Token => instance.token;
        public void SetToken(TokenModel token_) => instance.token = token_;

        public static TokenHolder Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (TokenHolder)FindObjectOfType(typeof(TokenHolder));
                    if ((instance == null))
                    {
                        Debug.LogWarning(typeof(TokenHolder) + "is nothing");
                    }
                }
                return instance;
            }
        }

        void Awake()
        {
            if (this.CheckInstance())
            {
                DontDestroyOnLoad(this.gameObject);
            }
        }

        bool CheckInstance()
        {
            if (instance == null)
            {
                instance = (TokenHolder)this;
                return true;
            }
            else if (Instance == this)
            {
                return true;
            }
            Destroy(this.gameObject);
            return false;
        }
    }
}
