using System;

namespace SpotifyApi.Models {
    public readonly struct DeviceId : IEquatable<DeviceId> {
        public readonly string value;
        public DeviceId(string value) => this.value = value;

        public bool Equals(DeviceId other) {
            return value == other.value;
        }

        public override bool Equals(object obj) {
            return obj is ArtistId other && Equals(other);
        }

        public override int GetHashCode() {
            return (value != null ? value.GetHashCode() : 0);
        }

        public static bool operator ==(DeviceId lhs, DeviceId rhs) {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(DeviceId lhs, DeviceId rhs) {
            return !(lhs == rhs);
        }

        public override string ToString() {
            return value;
        }
    }
}
