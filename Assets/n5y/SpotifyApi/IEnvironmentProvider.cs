namespace n5y.SpotifyApi {
    public interface IEnvironmentProvider {
        string ClientId { get; }
        string ClientSecret { get; }
        string RedirectUri { get; }
    }
}
