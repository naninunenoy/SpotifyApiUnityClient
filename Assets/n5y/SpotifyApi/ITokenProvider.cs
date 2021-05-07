using n5y.SpotifyApi.Models;

namespace n5y.SpotifyApi {
    public interface ITokenProvider {
        TokenModel Token { get; }
    }
}
