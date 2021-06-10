using System;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core.View {
    public interface IListViewTrigger {
        IObservable<Unit> OnClose { get; }
        IObservable<Unit> OnPlaylistSelect { get; }
        IObservable<Unit> OnAlbumSelect { get; }
        IObservable<Unit> OnDeviceSelect { get; }
        IObservable<PlaylistId> OnDecidePlaylist { get; }
        IObservable<AlbumId> OnDecideAlbum { get; }
        IObservable<DeviceId> OnDecideDevice { get; }
        IObservable<MusicId> OnDecideMusic { get; }
    }
}
