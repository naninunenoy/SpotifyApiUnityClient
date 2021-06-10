using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IMusicQuery {
        UniTask<MusicData> GetMusicDataAsync(MusicId musicId, CancellationToken cancellationToken);
    }
}
