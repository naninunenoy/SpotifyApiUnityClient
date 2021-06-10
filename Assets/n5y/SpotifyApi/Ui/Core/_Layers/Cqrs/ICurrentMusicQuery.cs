using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface ICurrentMusicQuery {
        UniTask<CurrentMusic> GetCurrentMusic(CancellationToken cancellationToken);
    }
}
