using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core.View {
    public interface IMusicListPresentation {
        void SetPlaylists(IAsyncSubscriber<PlaylistTuple> playlistAsync);
        void SetAlbums(IAsyncSubscriber<AlbumTuple> albumAsync);
        void SetDevices(IAsyncSubscriber<DeviceTuple> deviceAsync);
        void SetPlaylistMusicAsync(IAsyncSubscriber<PlaylistId, MusicTuple> musicAsync);
        void SetAlbumMusicAsync(IAsyncSubscriber<AlbumId, MusicTuple> musicAsync);
        void ClearPlaylist(PlaylistId playlistId);
        void ClearAlbum(AlbumId albumId);
    }
}
