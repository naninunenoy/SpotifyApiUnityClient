namespace n5y.SpotifyApi {
    public static class RuntimeEnvironment {
        public const string ClientId = "<< ** INPUT YOUR CLIENT_ID ** >>";
        public const string ClientSecret = "<< ** INPUT YOUR CLIENT_SECRET ** >>";
        public const string RedirectUri = "<< ** INPUT YOUR REDIRECT_URI ** >>";
    }

    public class RuntimeEnvironmentProvider : IEnvironmentProvider {
        public string ClientId => RuntimeEnvironment.ClientId;
        public string ClientSecret => RuntimeEnvironment.ClientSecret;
        public string RedirectUri => RuntimeEnvironment.RedirectUri;
    }
}
