using System;
using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.View;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core {
    public class MusicSyncAgent : AgentBase {
        readonly IObservable<Unit> syncObservable;
        readonly ICurrentMusicQuery currentMusicQuery;
        readonly ICurrentMusicPublisher currentMusicPublisher;
        readonly IMusicControlPresentation musicControlPresentation;

        public MusicSyncAgent(IObservable<Unit> syncObservable, ICurrentMusicQuery currentMusicQuery,
            ICurrentMusicPublisher currentMusicPublisher, IMusicControlPresentation musicControlPresentation) {
            this.syncObservable = syncObservable;
            this.currentMusicQuery = currentMusicQuery;
            this.currentMusicPublisher = currentMusicPublisher;
            this.musicControlPresentation = musicControlPresentation;
        }

        public void Process() {
            // 一定時間毎に現在再生されている音楽を取得して通知する
            syncObservable
                .Subscribe(_ => UniTask.Void(async () => {
                    // 現在の音楽の情報(更新の有無に関係なく通知)
                    var current = await currentMusicQuery.GetCurrentMusic(agentCts.Token);
                    currentMusicPublisher.NewMusic.Publish(current.Music);
                    // 時間の表示を更新
                    var elapsedSeconds = current.ProgressMs / 1000.0F;
                    var timeTuple = new MusicTimeTuple(elapsedSeconds, current.Music.TotalSeconds);
                    var playState = current.IsPlaying ? MusicPlayState.Playing : MusicPlayState.Paused;
                    musicControlPresentation.SetTime(timeTuple);
                    musicControlPresentation.SetPlayState(playState);
                }))
                .AddTo(agentDisposable);
        }
    }
}
