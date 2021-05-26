using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IAlbumQuery {
        IAsyncSubscriber<AlbumTuple> QueryAsync { get; }
    }
}
