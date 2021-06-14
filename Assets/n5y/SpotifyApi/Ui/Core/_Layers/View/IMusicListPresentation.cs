using System;
using System.Collections.Generic;

namespace n5y.SpotifyApi.Ui.Core.View {
    public interface IMusicListPresentation {
        void AddPlaylist(PlaylistTuple playlist);
        void AddAlbum(AlbumTuple album);
        void AddDevice(DeviceTuple device);
        void AddPlaylistMusic(PlaylistId playlistId, MusicTuple music);
        void AddAlbumMusic(AlbumId albumId, MusicTuple music);
    }
}
