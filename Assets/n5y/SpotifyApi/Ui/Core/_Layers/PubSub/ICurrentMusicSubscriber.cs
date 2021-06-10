using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.PubSub {
    public interface ICurrentMusicSubscriber {
        IBufferedSubscriber<MusicData> Music { get; }
    }
}
