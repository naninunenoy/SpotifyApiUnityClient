using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.PubSub {
    public interface IMusicSubscriber {
        ISubscriber<MusicData> MusicData { get; }
    }
}
