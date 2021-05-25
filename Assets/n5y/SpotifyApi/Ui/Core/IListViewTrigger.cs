using System;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core {
    public interface IListViewTrigger {
        IObservable<Unit> OnCloseTrigger { get; }
        IObservable<Unit> OnPlaylistSelectTrigger { get; }
        IObservable<Unit> OnAlbumSelectTrigger { get; }
        IObservable<Unit> OnDeviceSelectTrigger { get; }
    }
}
