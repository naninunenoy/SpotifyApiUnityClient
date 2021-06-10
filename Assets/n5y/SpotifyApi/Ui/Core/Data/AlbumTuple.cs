using System;

namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct AlbumTuple : IEquatable<AlbumTuple> {
        public readonly AlbumId albumId;
        public readonly string name;

        public AlbumTuple(AlbumId albumId, string name) {
            this.albumId = albumId;
            this.name = name;
        }

        public bool Equals(AlbumTuple other) {
            return albumId.Equals(other.albumId) && name == other.name;
        }

        public override bool Equals(object obj) {
            return obj is AlbumTuple other && Equals(other);
        }

        public override int GetHashCode() {
            unchecked {
                return (albumId.GetHashCode() * 397) ^ (name != null ? name.GetHashCode() : 0);
            }
        }
    }
}
