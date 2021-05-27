using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.PubSub {
    public interface IMusicSelectPublisher {
        IPublisher<MusicId> MusicSelect { get; }
        IPublisher<DeviceId> DeviceSelect { get; }
    }
}
