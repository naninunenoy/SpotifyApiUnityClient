﻿using System;

namespace SpotifyApi.Models {
    public readonly struct AlbumId : IEquatable<AlbumId> {
        public readonly string value;
        public AlbumId(string value) => this.value = value;

        public bool Equals(AlbumId other) {
            return value == other.value;
        }

        public override bool Equals(object obj) {
            return obj is ArtistId other && Equals(other);
        }

        public override int GetHashCode() {
            return (value != null ? value.GetHashCode() : 0);
        }

        public static bool operator ==(AlbumId lhs, AlbumId rhs) {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(AlbumId lhs, AlbumId rhs) {
            return !(lhs == rhs);
        }

        public override string ToString() {
            return value;
        }
    }
}
