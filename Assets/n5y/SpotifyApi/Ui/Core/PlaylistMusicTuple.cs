namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct PlaylistMusicTuple {
        public readonly PlaylistTuple playlist;
        public readonly MusicTuple music;

        public PlaylistMusicTuple(PlaylistTuple playlist, MusicTuple music) {
            this.playlist = playlist;
            this.music = music;
        }
    }
}
