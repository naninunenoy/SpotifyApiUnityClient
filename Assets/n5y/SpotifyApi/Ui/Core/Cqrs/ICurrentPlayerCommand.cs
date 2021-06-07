using System.Threading;
using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface ICurrentPlayerCommand {
        UniTask PushCurrentMusic(MusicId musicId, CancellationToken cancellationToken);
        UniTask PushCurrentDevice(DeviceId deviceId, CancellationToken cancellationToken);
    }
}
