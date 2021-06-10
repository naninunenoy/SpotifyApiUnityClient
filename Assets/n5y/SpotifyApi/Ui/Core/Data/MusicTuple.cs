using System;

namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct MusicTuple : IEquatable<MusicTuple> {
        public readonly MusicId musicId;
        public readonly string name;

        public MusicTuple(MusicId musicId, string name) {
            this.musicId = musicId;
            this.name = name;
        }

        public bool Equals(MusicTuple other) {
            return musicId.Equals(other.musicId) && name == other.name;
        }

        public override bool Equals(object obj) {
            return obj is MusicTuple other && Equals(other);
        }

        public override int GetHashCode() {
            unchecked {
                return (musicId.GetHashCode() * 397) ^ (name != null ? name.GetHashCode() : 0);
            }
        }
    }
}
