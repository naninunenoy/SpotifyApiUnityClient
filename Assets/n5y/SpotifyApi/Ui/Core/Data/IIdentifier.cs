using System;

namespace n5y.SpotifyApi.Ui.Core {
    public interface IIdentifier {
        string Identifier { get; }
    }
    public readonly struct MusicId : IEquatable<MusicId>, IIdentifier {
        public string Identifier { get; }
        public MusicId(string id) => Identifier = id;
        public bool Equals(MusicId other) => Identifier == other.Identifier;
        public override bool Equals(object obj) => obj is MusicId other && Equals(other);
        public override int GetHashCode() => (Identifier != null ? Identifier.GetHashCode() : 0);
        public static bool operator ==(MusicId l, MusicId r) => l.Equals(r);
        public static bool operator !=(MusicId l, MusicId r) => !(l == r);
        public static MusicId Empty() => new MusicId("");
    }
    public readonly struct AlbumId : IEquatable<AlbumId>, IIdentifier {
        public string Identifier { get; }
        public AlbumId(string id) => Identifier = id;
        public bool Equals(AlbumId other) => Identifier == other.Identifier;
        public override bool Equals(object obj) => obj is AlbumId other && Equals(other);
        public override int GetHashCode() => (Identifier != null ? Identifier.GetHashCode() : 0);
        public static bool operator ==(AlbumId l, AlbumId r) => l.Equals(r);
        public static bool operator !=(AlbumId l, AlbumId r) => !(l == r);
        public static AlbumId Empty() => new AlbumId("");
    }
    public readonly struct PlaylistId : IEquatable<PlaylistId>, IIdentifier {
        public string Identifier { get; }
        public PlaylistId(string id) => Identifier = id;
        public bool Equals(PlaylistId other) => Identifier == other.Identifier;
        public override bool Equals(object obj) => obj is PlaylistId other && Equals(other);
        public override int GetHashCode() => (Identifier != null ? Identifier.GetHashCode() : 0);
        public static bool operator ==(PlaylistId l, PlaylistId r) => l.Equals(r);
        public static bool operator !=(PlaylistId l, PlaylistId r) => !(l == r);
        public static PlaylistId Empty() => new PlaylistId("");
    }
    public readonly struct DeviceId : IEquatable<DeviceId>, IIdentifier {
        public string Identifier { get; }
        public DeviceId(string id) => Identifier = id;
        public bool Equals(DeviceId other) => Identifier == other.Identifier;
        public override bool Equals(object obj) => obj is DeviceId other && Equals(other);
        public override int GetHashCode() => (Identifier != null ? Identifier.GetHashCode() : 0);
        public static bool operator ==(DeviceId l, DeviceId r) => l.Equals(r);
        public static bool operator !=(DeviceId l, DeviceId r) => !(l == r);
        public static DeviceId Empty() => new DeviceId("");
    }
}
