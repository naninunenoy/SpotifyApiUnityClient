using Cysharp.Threading.Tasks;
using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IMusicQuery {
        IAsyncSubscriber<MusicTuple> QueryAsync { get; }
        UniTask<MusicData> GetMusicByIdAsync(MusicId musicId);
    }
}
