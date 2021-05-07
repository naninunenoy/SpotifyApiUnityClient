namespace n5y.SpotifyApi {
    public static partial class Api {
        public static string GetAuthorizeUrl(string clientId, string redirectUrl, string scopes) {
            var scopesParam = string.IsNullOrEmpty(scopes) ? "" : $"&scope={scopes}";
            return $"{Endpoints.Authorize}?client_id={clientId}&response_type=code&redirect_uri={redirectUrl}{scopesParam}";
        }
    }
}
