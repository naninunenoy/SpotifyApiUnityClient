using System;
using System.Threading;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core {
    public abstract class AgentBase : IDisposable {
        protected IDisposable agentInnerDisposable;
        protected readonly CancellationTokenSource agentCts = new CancellationTokenSource();
        protected readonly CompositeDisposable agentDisposable = new CompositeDisposable();

        public virtual void Dispose() {
            agentInnerDisposable?.Dispose();
            agentCts.Cancel();
            agentDisposable.Clear();
        }
    }
}
