using System.Threading;
using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Models;

namespace n5y.SpotifyApi.SpotifyConnect {
    public interface ISpotifyConnectApiAdapter {
        UniTask<CurrentlyPlayingTrackModel> GetCurrentlyPlayingAsync(CancellationToken cancellationToken);
    }
}
