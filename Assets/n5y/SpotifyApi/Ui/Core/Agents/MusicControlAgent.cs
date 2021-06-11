using Cysharp.Threading.Tasks;
using MessagePipe;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.PubSub;
using n5y.SpotifyApi.Ui.Core.View;
using UniRx;
using UnityEngine;

namespace n5y.SpotifyApi.Ui.Core {
    public class MusicControlAgent : AgentBase {
        readonly ICurrentMusicSubscriber currentMusicSubscriber;
        readonly IMusicControlCommand musicControlCommand;
        readonly IMusicControlPresentation controlPresentation;
        readonly IMusicViewTrigger musicViewTrigger;
        MusicData currentMusic = default;
        MusicPlayState state;

        public MusicControlAgent(ICurrentMusicSubscriber currentMusicSubscriber, IMusicControlCommand musicControlCommand,
            IMusicControlPresentation controlPresentation, IMusicViewTrigger musicViewTrigger) {
            this.currentMusicSubscriber = currentMusicSubscriber;
            this.musicControlCommand = musicControlCommand;
            this.controlPresentation = controlPresentation;
            this.musicViewTrigger = musicViewTrigger;
        }

        public void Process() {
            state = MusicPlayState.Paused;
            var bag = DisposableBag.CreateBuilder();
            currentMusicSubscriber.Music
                .Subscribe(x => {
                    currentMusic = x;
                })
                .AddTo(bag);
            agentInnerDisposable = bag.Build();
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
            musicViewTrigger.SeekValue
                .Where(_ => currentMusic != null && currentMusic.TotalSeconds > 0.0F)
                .Select(x => x * currentMusic.TotalSeconds)
                .Select(x => Mathf.RoundToInt(x * 1000))
                .Subscribe(x => { musicControlCommand.SeekAsync(x, agentCts.Token).Forget(); })
                .AddTo(agentDisposable);
        }
    }
}
