using n5y.SpotifyApi.Models;

namespace n5y.SpotifyApi {
    public interface ITokenProvider {
        string GetAuthorizationHeaderValue();
    }
}
