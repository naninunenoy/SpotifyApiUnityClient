using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core {
    public interface IMusicCatalogQuery {
        IUniTaskAsyncEnumerable<PlaylistTuple> GetPlaylistsAsync(CancellationToken cancellationToken);
        IUniTaskAsyncEnumerable<AlbumTuple> GetAlbumsAsync(CancellationToken cancellationToken);
        IUniTaskAsyncEnumerable<DeviceTuple> GetDevicesAsync(CancellationToken cancellationToken);

        IUniTaskAsyncEnumerable<MusicTuple> GetMusicsAsync(PlaylistId playlistId, CancellationToken cancellationToken);
        IUniTaskAsyncEnumerable<MusicTuple> GetMusicsAsync(AlbumId albumId, CancellationToken cancellationToken);
    }
}
