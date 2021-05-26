using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Trigger {
    public interface IMusicSubscriber {
        ISubscriber<MusicData> MusicData { get; }
    }
}
