using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IPlaylistQuery {
        IAsyncSubscriber<PlaylistTuple> QueryAsync { get; }
    }
}
