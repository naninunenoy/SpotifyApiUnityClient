using Cysharp.Threading.Tasks;

namespace n5y.SpotifyApi.Ui.Core {
    public interface ICurrentPlayerCommand {
        UniTask PushCurrentMusic(MusicId musicId);
        UniTask PushCurrentDevice(DeviceId deviceId);
    }
}
