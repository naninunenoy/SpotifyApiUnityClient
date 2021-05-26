using System;
using System.Collections.Generic;

namespace n5y.SpotifyApi.Ui.Core.View {
    public interface IMusicListPresentation {
        void AddPlaylist(PlaylistTuple playlist);
        void AddAlbum(AlbumTuple album);
        IObservable<DeviceId> AddDevice(DeviceTuple device);
        IObservable<MusicId> AddPlaylistMusic(PlaylistId playlistId, MusicTuple music);
        IObservable<MusicId> AddAlbumMusic(AlbumId albumId, MusicTuple music);
    }
}
