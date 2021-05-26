using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core {
    public interface IMusicSelectPublisher {
        IPublisher<MusicId> MusicSelect { get; }
        IPublisher<DeviceId> DeviceSelect { get; }
    }
}
