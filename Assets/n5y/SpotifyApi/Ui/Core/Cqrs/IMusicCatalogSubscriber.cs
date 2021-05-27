using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IMusicCatalogSubscriber {
        ISubscriber<PlaylistTuple> Playlist { get; }
        ISubscriber<AlbumTuple> Album { get; }
        ISubscriber<DeviceTuple> Device { get; }
        ISubscriber<PlaylistMusicTuple> PlaylistMusic { get; }
        ISubscriber<AlbumMusicTuple> AlbumMusic { get; }
    }
}
