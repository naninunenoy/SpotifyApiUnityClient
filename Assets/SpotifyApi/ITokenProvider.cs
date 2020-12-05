using SpotifyApi.Models;

namespace SpotifyApi {
    public interface ITokenProvider {
        TokenModel Token { get; }
    }
}
