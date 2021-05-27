using System;
using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core {
    public class CurrentMusicAgent : AgentBase {
        readonly IObservable<MusicId> onSelectMusic;
        readonly IMusicQuery musicQuery;
        readonly ICurrentMusicPublisher musicPublisher;

        public CurrentMusicAgent(IObservable<MusicId> onSelectMusic, IMusicQuery musicQuery,
            ICurrentMusicPublisher musicPublisher) {
            this.onSelectMusic = onSelectMusic;
            this.musicQuery = musicQuery;
            this.musicPublisher = musicPublisher;
        }

        public void Process() {
            // 新しい音楽が選択されたら詳細を取得して表示する
            onSelectMusic
                .Subscribe(id => UniTask.Void(async () => {
                    var music = await musicQuery.GetMusicDataAsync(id, agentCts.Token);
                    musicPublisher.NewMusic.Publish(music);
                }))
                .AddTo(agentDisposable);
        }
    }
}
