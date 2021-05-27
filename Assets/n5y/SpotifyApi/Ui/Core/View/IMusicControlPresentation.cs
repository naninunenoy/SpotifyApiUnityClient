namespace n5y.SpotifyApi.Ui.Core.View {
    public interface IMusicControlPresentation {
        void SetPlayState(MusicPlayState state);
        void SetTime(MusicTimeTuple musicTime);
    }
}
