namespace n5y.SpotifyApi.Ui.Core.View {
    public enum PlayState {
        Playing,
        Paused
    }

    public readonly struct MusicTimeTuple {
        public readonly float elapsedSeconds;
        public readonly float totalSeconds;
        public MusicTimeTuple(float elapsedSeconds, float totalSeconds) {
            this.elapsedSeconds = elapsedSeconds;
            this.totalSeconds = totalSeconds;
        }
    }

    public interface IMusicControlPresentation {
        void SetPlayState(PlayState state);
        void SetTime(MusicTimeTuple musicTime);
    }
}
