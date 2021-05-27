namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct AlbumMusicTuple {
        public readonly AlbumTuple album;
        public readonly MusicTuple music;

        public AlbumMusicTuple(AlbumTuple album, MusicTuple music) {
            this.album = album;
            this.music = music;
        }
    }
}
