namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct AlbumMusicTuple {
        public readonly AlbumId albumId;
        public readonly MusicTuple music;

        public AlbumMusicTuple(AlbumId albumId, MusicTuple music) {
            this.albumId = albumId;
            this.music = music;
        }
    }
}
