using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public interface IDeviceQuery {
        IAsyncSubscriber<DeviceTuple> QueryAsync { get; }
    }
}
