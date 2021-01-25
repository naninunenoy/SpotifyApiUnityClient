using System.Threading;
using Cysharp.Threading.Tasks;
using SpotifyApi.Models;

namespace SpotifyApi.SpotifyConnect {
    public class SpotifyConnectApiAdapter : ISpotifyConnectApiAdapter {
        ITokenProvider tokenProvider;

        public SpotifyConnectApiAdapter(ITokenProvider tokenProvider) {
            this.tokenProvider = tokenProvider;
        }

        UniTask<CurrentlyPlayingTrackModel> ISpotifyConnectApiAdapter.GetCurrentlyPlayingAsync(
            CancellationToken cancellationToken) {
            return Api.Player.GetCurrentlyPlayingAsync(tokenProvider, cancellationToken);
        }
    }
}
