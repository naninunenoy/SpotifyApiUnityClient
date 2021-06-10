using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core {
    public interface IMusicCatalogPublisher {
        IPublisher<PlaylistTuple> Playlist { get; }
        IPublisher<AlbumTuple> Album { get; }
        IPublisher<DeviceTuple> Device { get; }
        IPublisher<PlaylistMusicTuple> PlaylistMusic { get; }
        IPublisher<AlbumMusicTuple> AlbumMusic { get; }
    }
}
