using System;

namespace SpotifyApi.Models {
    public readonly struct  PlaylistId : IEquatable<PlaylistId> {
        public readonly string value;
        public PlaylistId(string value) => this.value = value;

        public bool Equals(PlaylistId other) {
            return value == other.value;
        }

        public override bool Equals(object obj) {
            return obj is ArtistId other && Equals(other);
        }

        public override int GetHashCode() {
            return (value != null ? value.GetHashCode() : 0);
        }

        public static bool operator ==(PlaylistId lhs, PlaylistId rhs) {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(PlaylistId lhs, PlaylistId rhs) {
            return !(lhs == rhs);
        }

        public override string ToString() {
            return value;
        }
    }
}
