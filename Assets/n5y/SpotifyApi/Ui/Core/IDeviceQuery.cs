using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct DeviceTuple {
        public readonly DeviceId deviceId;
        public readonly string name;

        public DeviceTuple(DeviceId deviceId, string name) {
            this.deviceId = deviceId;
            this.name = name;
        }
    }

    public interface IDeviceQuery {
        IAsyncSubscriber<DeviceTuple> QueryAsync { get; }
    }
}
