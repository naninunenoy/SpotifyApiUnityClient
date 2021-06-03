using System.Threading;
using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Models;

namespace n5y.SpotifyApi.SpotifyConnect {
    public class SpotifyConnectApiAdapter : ISpotifyConnectApiAdapter {
        ITokenProvider tokenProvider;

        public SpotifyConnectApiAdapter(ITokenProvider tokenProvider) {
            this.tokenProvider = tokenProvider;
        }

        UniTask<CurrentlyPlayingTrackModel> ISpotifyConnectApiAdapter.GetCurrentlyPlayingAsync(
            CancellationToken cancellationToken) {
            return Api.GetCurrentlyPlayingAsync(tokenProvider, cancellationToken);
        }
    }
}
