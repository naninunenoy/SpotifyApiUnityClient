namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct AlbumTuple {
        public readonly AlbumId albumId;
        public readonly string name;

        public AlbumTuple(AlbumId albumId, string name) {
            this.albumId = albumId;
            this.name = name;
        }
    }
}
