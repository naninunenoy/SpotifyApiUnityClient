using System;

namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct DeviceTuple : IEquatable<DeviceTuple> {
        public readonly DeviceId deviceId;
        public readonly string name;

        public DeviceTuple(DeviceId deviceId, string name) {
            this.deviceId = deviceId;
            this.name = name;
        }

        public bool Equals(DeviceTuple other) {
            return deviceId.Equals(other.deviceId) && name == other.name;
        }

        public override bool Equals(object obj) {
            return obj is DeviceTuple other && Equals(other);
        }

        public override int GetHashCode() {
            unchecked {
                return (deviceId.GetHashCode() * 397) ^ (name != null ? name.GetHashCode() : 0);
            }
        }
    }
}
