using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi {
    public interface IRefreshTokenStorage {
        UniTask<string> LoadAsync(CancellationToken cancellationToken);
        UniTask SaveAsync(string refreshToken, CancellationToken cancellationToken);
        UniTask DeleteAsync(CancellationToken cancellationToken);
        UniTask<bool> ContainsAsync(CancellationToken cancellationToken);
    }
}
