using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IMusicQuery {
        IAsyncSubscriber<PlaylistTuple> QueryAsync { get; }
    }
}
