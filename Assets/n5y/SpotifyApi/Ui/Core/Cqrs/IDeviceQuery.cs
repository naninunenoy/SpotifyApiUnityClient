using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IDeviceQuery {
        ISubscriber<DeviceTuple> Device { get; }
    }
}
