using System;

namespace SpotifyApi.Models {
    public readonly struct UserId : IEquatable<UserId> {
        public readonly string value;
        public UserId(string value) => this.value = value;

        public bool Equals(UserId other) {
            return value == other.value;
        }

        public override bool Equals(object obj) {
            return obj is ArtistId other && Equals(other);
        }

        public override int GetHashCode() {
            return (value != null ? value.GetHashCode() : 0);
        }

        public static bool operator ==(UserId lhs, UserId rhs) {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(UserId lhs, UserId rhs) {
            return !(lhs == rhs);
        }

        public override string ToString() {
            return value;
        }
    }
}
