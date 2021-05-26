using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IAlbumQuery {
        ISubscriber<AlbumTuple> Album { get; }
    }
}
