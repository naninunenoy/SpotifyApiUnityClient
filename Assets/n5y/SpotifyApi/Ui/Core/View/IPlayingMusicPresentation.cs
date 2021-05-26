using UnityEngine;

namespace n5y.SpotifyApi.Ui.Core.View {
    public interface IPlayingMusicPresentation {
        void SetTitle(string title);
        void SetAlbumName(string albumName);
        void SetArtistName(string artistName);
        void SetArtwork(Sprite artwork);
    }
}
