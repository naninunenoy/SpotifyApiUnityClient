using System.Threading;
using Cysharp.Threading.Tasks;
using SpotifyApi.Models;

namespace SpotifyApi.SpotifyConnect {
    public interface ISpotifyConnectApiAdapter {
        UniTask<CurrentlyPlayingTrackModel> GetCurrentlyPlayingAsync(CancellationToken cancellationToken);
    }
}
