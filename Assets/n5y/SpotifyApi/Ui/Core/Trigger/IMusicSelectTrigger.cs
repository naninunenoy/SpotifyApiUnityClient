using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Trigger {
    public interface IMusicSelectTrigger {
        IAsyncSubscriber<MusicId> MusicSelectAsync { get; }
        IAsyncSubscriber<DeviceId> DeviceSelectAsync { get; }
    }
}
