using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Ui.Core.View;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core {
    public class MusicControlAgent : AgentBase {
        readonly IMusicControlCommand musicControlCommand;
        readonly IMusicControlPresentation controlPresentation;
        readonly IMusicViewTrigger musicViewTrigger;
        MusicPlayState state;

        public MusicControlAgent(IMusicControlCommand musicControlCommand,
            IMusicControlPresentation controlPresentation, IMusicViewTrigger musicViewTrigger) {
            this.musicControlCommand = musicControlCommand;
            this.controlPresentation = controlPresentation;
            this.musicViewTrigger = musicViewTrigger;
        }

        public void Process() {
            state = MusicPlayState.Paused;
            BindControlCommand();
        }

        void BindControlCommand() {
            musicViewTrigger.OnPlay
                .Subscribe(_ => UniTask.Void(async () => {
                    if (state == MusicPlayState.Playing) {
                        await musicControlCommand.PauseAsync(agentCts.Token);
                        state = MusicPlayState.Paused;
                    } else {
                        await musicControlCommand.ResumeAsync(agentCts.Token);
                        state = MusicPlayState.Playing;
                    }
                    controlPresentation.SetPlayState(state);
                }))
                .AddTo(agentDisposable);
            musicViewTrigger.OnNext
                .Subscribe(_ => { musicControlCommand.GoNextAsync(agentCts.Token).Forget(); })
                .AddTo(agentDisposable);
            musicViewTrigger.OnPrevious
                .Subscribe(_ => { musicControlCommand.GoBackAsync(agentCts.Token).Forget(); })
                .AddTo(agentDisposable);
        }
    }
}
