using System;

namespace SpotifyApi.Models {
    public readonly struct TrackId : IEquatable<TrackId> {
        public readonly string value;
        public TrackId(string value) => this.value = value;

        public bool Equals(TrackId other) {
            return value == other.value;
        }

        public override bool Equals(object obj) {
            return obj is ArtistId other && Equals(other);
        }

        public override int GetHashCode() {
            return (value != null ? value.GetHashCode() : 0);
        }

        public static bool operator ==(TrackId lhs, TrackId rhs) {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TrackId lhs, TrackId rhs) {
            return !(lhs == rhs);
        }

        public override string ToString() {
            return value;
        }

        public static TrackId Empty => new TrackId("");
    }
}
