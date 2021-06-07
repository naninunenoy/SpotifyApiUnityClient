using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.View;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core {
    public class CurrentPlayerAgent : AgentBase {
        readonly IListViewTrigger listViewTrigger;
        readonly IMusicQuery musicQuery;
        readonly ICurrentPlayerCommand playerCommand;
        readonly ICurrentMusicPublisher musicPublisher;

        public CurrentPlayerAgent(IListViewTrigger listViewTrigger, IMusicQuery musicQuery,
            ICurrentPlayerCommand playerCommand, ICurrentMusicPublisher musicPublisher) {
            this.listViewTrigger = listViewTrigger;
            this.musicQuery = musicQuery;
            this.playerCommand = playerCommand;
            this.musicPublisher = musicPublisher;
        }

        public void Process() {
            listViewTrigger
                .OnDecideMusic
                .Subscribe(id => UniTask.Void(async () => {
                    // 選択された音楽を通知
                    playerCommand.PushCurrentMusic(id, agentCts.Token).Forget();
                    // 新しい音楽が選択されたら詳細を取得して表示する
                    var music = await musicQuery.GetMusicDataAsync(id, agentCts.Token);
                    musicPublisher.NewMusic.Publish(music);
                }))
                .AddTo(agentDisposable);

            listViewTrigger
                .OnDecideDevice
                .Subscribe(id => {
                    // 選択された音楽を通知
                    playerCommand.PushCurrentDevice(id, agentCts.Token).Forget();
                })
                .AddTo(agentDisposable);
        }
    }
}
