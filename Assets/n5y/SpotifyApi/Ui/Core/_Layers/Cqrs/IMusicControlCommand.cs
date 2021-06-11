using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IMusicControlCommand {
        UniTask ResumeAsync(CancellationToken cancellationToken);
        UniTask PauseAsync(CancellationToken cancellationToken);
        UniTask GoNextAsync(CancellationToken cancellationToken);
        UniTask GoBackAsync(CancellationToken cancellationToken);
        UniTask SeekAsync(int milliSeconds, CancellationToken cancellationToken);
    }
}
