using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public readonly struct MusicTuple {
        public readonly MusicId musicId;
        public readonly string name;

        public MusicTuple(MusicId musicId, string name) {
            this.musicId = musicId;
            this.name = name;
        }
    }

    public interface IMusicQuery {
        IAsyncSubscriber<PlaylistTuple> QueryAsync { get; }
    }
}
