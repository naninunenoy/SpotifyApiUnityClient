using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.PubSub {
    public interface IMusicSelectSubscriber {
        ISubscriber<MusicId> MusicSelect { get; }
        ISubscriber<DeviceId> DeviceSelect { get; }
    }
}
