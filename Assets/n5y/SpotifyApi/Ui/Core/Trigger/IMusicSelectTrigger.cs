using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Trigger {
    public interface IMusicSelectTrigger {
        IAsyncPublisher<MusicId> MusicSelectAsync { get; }
        IAsyncPublisher<DeviceId> DeviceSelectAsync { get; }
    }
}
