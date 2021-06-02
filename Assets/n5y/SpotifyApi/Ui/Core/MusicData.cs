namespace n5y.SpotifyApi.Ui.Core {
    public class MusicData {
        public string MusicName { get; }
        public string AlbumName { get; }
        public string ArtistName { get; }
        public string ArtworkUrl { get; }
        public float TotalSeconds { get; }

        public MusicData(string musicName, string albumName, string artistName, string artworkUrl, float totalSeconds) {
            MusicName = musicName;
            AlbumName = albumName;
            ArtistName = artistName;
            ArtworkUrl = artworkUrl;
            TotalSeconds = totalSeconds;
        }

        // TotalSeconds が0だと零除算が起きそうなので Epsilon を渡している
        public static MusicData Empty() => new MusicData("", "", "", "", float.Epsilon);
    }
}
