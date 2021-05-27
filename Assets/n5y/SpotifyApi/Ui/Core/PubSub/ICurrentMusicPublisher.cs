using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core
{
    public interface ICurrentMusicPublisher
    {
        IPublisher<MusicData> NewMusic { get; }
    }
}
