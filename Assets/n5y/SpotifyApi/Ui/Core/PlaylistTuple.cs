using System;

namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct PlaylistTuple : IEquatable<PlaylistTuple> {
        public readonly PlaylistId playlistId;
        public readonly string name;

        public PlaylistTuple(PlaylistId playlistId, string name) {
            this.playlistId = playlistId;
            this.name = name;
        }

        public bool Equals(PlaylistTuple other) {
            return playlistId.Equals(other.playlistId) && name == other.name;
        }

        public override bool Equals(object obj) {
            return obj is PlaylistTuple other && Equals(other);
        }

        public override int GetHashCode() {
            unchecked {
                return (playlistId.GetHashCode() * 397) ^ (name != null ? name.GetHashCode() : 0);
            }
        }
    }
}
