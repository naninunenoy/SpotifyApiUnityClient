using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public readonly struct PlaylistTuple {
        public readonly PlaylistId playlistId;
        public readonly string name;
        public PlaylistTuple(PlaylistId playlistId, string name) {
            this.playlistId = playlistId;
            this.name = name;
        }
    }
    public interface IPlaylistQuery {
        IAsyncSubscriber<PlaylistTuple> QueryAsync { get; }
    }
}
