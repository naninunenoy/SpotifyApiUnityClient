namespace n5y.SpotifyApi.Ui.Core {
    public class CurrentMusic {
        public CurrentMusic(bool isPlaying, int progressMs, MusicData music) {
            IsPlaying = isPlaying;
            ProgressMs = progressMs;
            Music = music;
        }

        public bool IsPlaying { get; }
        public int ProgressMs { get; }
        public MusicData Music { get; }

        public static CurrentMusic Empty() => new CurrentMusic(false, 0, MusicData.Empty());
    }
}
