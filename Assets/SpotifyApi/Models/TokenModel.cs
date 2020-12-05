using System;
using UnityEngine;

namespace SpotifyApi.Models {
    [Serializable]
    public class TokenModel {
        [SerializeField] string access_token;
        [SerializeField] string token_type;
        [SerializeField] int expires_in;
        [SerializeField] string refresh_token;
        [SerializeField] string scope;

        public string AccessToken => access_token;
        public string TokenType => token_type;
        public int ExpiresIn => expires_in;
        public string RefreshToken => refresh_token;
        public string Scope => scope;
    }

    public static class TokenModelExtension {
        public static string GetAuthorizationHeaderValue(this TokenModel token) {
            return $"{token.TokenType} {token.AccessToken}";
        }
    }
}
