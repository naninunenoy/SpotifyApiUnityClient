using System;

namespace n5y.SpotifyApi.Ui.Core {
    public interface IIdentifier {
        string id { get; }
    }
    public readonly struct MusicId : IEquatable<MusicId>, IIdentifier {
        public string id { get; }
        public MusicId(string id) => this.id = id;
        public bool Equals(MusicId other) => id == other.id;
        public override bool Equals(object obj) => obj is MusicId other && Equals(other);
        public override int GetHashCode() => (id != null ? id.GetHashCode() : 0);
        public static bool operator ==(MusicId l, MusicId r) => l.Equals(r);
        public static bool operator !=(MusicId l, MusicId r) => !(l == r);
    }
    public readonly struct AlbumId : IEquatable<AlbumId>, IIdentifier {
        public string id { get; }
        public AlbumId(string id) => this.id = id;
        public bool Equals(AlbumId other) => id == other.id;
        public override bool Equals(object obj) => obj is AlbumId other && Equals(other);
        public override int GetHashCode() => (id != null ? id.GetHashCode() : 0);
        public static bool operator ==(AlbumId l, AlbumId r) => l.Equals(r);
        public static bool operator !=(AlbumId l, AlbumId r) => !(l == r);
    }
    public readonly struct PlaylistId : IEquatable<PlaylistId>, IIdentifier {
        public string id { get; }
        public PlaylistId(string id) => this.id = id;
        public bool Equals(PlaylistId other) => id == other.id;
        public override bool Equals(object obj) => obj is PlaylistId other && Equals(other);
        public override int GetHashCode() => (id != null ? id.GetHashCode() : 0);
        public static bool operator ==(PlaylistId l, PlaylistId r) => l.Equals(r);
        public static bool operator !=(PlaylistId l, PlaylistId r) => !(l == r);
    }
    public readonly struct DeviceId : IEquatable<DeviceId>, IIdentifier {
        public string id { get; }
        public DeviceId(string id) => this.id = id;
        public bool Equals(DeviceId other) => id == other.id;
        public override bool Equals(object obj) => obj is DeviceId other && Equals(other);
        public override int GetHashCode() => (id != null ? id.GetHashCode() : 0);
        public static bool operator ==(DeviceId l, DeviceId r) => l.Equals(r);
        public static bool operator !=(DeviceId l, DeviceId r) => !(l == r);
    }
}
