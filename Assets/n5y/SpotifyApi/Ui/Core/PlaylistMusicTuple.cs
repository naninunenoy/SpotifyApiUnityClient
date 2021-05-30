namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct PlaylistMusicTuple {
        public readonly PlaylistId playlistId;
        public readonly MusicTuple music;


        public PlaylistMusicTuple(PlaylistId playlistId, MusicTuple music) {
            this.playlistId = playlistId;
            this.music = music;
        }
    }
}
