using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class TokenModel {
        [JsonProperty("access_token")] public string AccessToken { private set; get; }
        [JsonProperty("token_type")] public string TokenType { private set; get; }
        [JsonProperty("expires_in")] public int ExpiresIn { private set; get; }
        [JsonProperty("refresh_token")] public string RefreshToken { private set; get; }
        [JsonProperty("scope")] public string Scope { private set; get; }
    }

    public static class TokenModelExtension {
        public static string GetAuthorizationHeaderValue(this TokenModel token) {
            return $"{token.TokenType} {token.AccessToken}";
        }
    }
}
