namespace n5y.SpotifyApi.Ui.Core {
    public class MusicData {
        public string MusicName { private set; get; }
        public string AlbumName { private set; get; }
        public string ArtistName { private set; get; }
        public string ArtworkUrl { private set; get; }
        public float TotalSeconds { private set; get; }

        public MusicData(string musicName, string albumName, string artistName, string artworkUrl, float totalSeconds) {
            MusicName = musicName;
            AlbumName = albumName;
            ArtistName = artistName;
            ArtworkUrl = artworkUrl;
            TotalSeconds = totalSeconds;
        }
    }
}
