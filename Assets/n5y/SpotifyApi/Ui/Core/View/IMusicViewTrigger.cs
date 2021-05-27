using System;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core.View {
    public interface IMusicViewTrigger {
        IObservable<Unit> OnListOpen { get; }
        IObservable<Unit> OnAuthorization { get; }
        IObservable<Unit> OnPlay { get; }
        IObservable<Unit> OnPrevious { get; }
        IObservable<Unit> OnNext { get; }
    }
}
