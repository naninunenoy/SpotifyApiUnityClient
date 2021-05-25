using System;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core {
    public interface IMusicViewTrigger {
        IObservable<Unit> OnListOpenTrigger { get; }
        IObservable<Unit> OnAuthorizationTrigger { get; }
        IObservable<Unit> OnPlayTrigger { get; }
        IObservable<Unit> OnPreviousTrigger { get; }
        IObservable<Unit> OnNextTrigger { get; }
    }
}
