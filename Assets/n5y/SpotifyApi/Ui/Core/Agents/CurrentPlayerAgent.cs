using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.PubSub;
using MessagePipe;

namespace n5y.SpotifyApi.Ui.Core {
    public class CurrentPlayerAgent : AgentBase {
        readonly IMusicSelectSubscriber musicSelectSubscriber;
        readonly IMusicQuery musicQuery;
        readonly ICurrentPlayerCommand playerCommand;
        readonly ICurrentMusicPublisher musicPublisher;

        public CurrentPlayerAgent(IMusicSelectSubscriber musicSelectSubscriber, IMusicQuery musicQuery,
            ICurrentPlayerCommand playerCommand, ICurrentMusicPublisher musicPublisher) {
            this.musicSelectSubscriber = musicSelectSubscriber;
            this.musicQuery = musicQuery;
            this.playerCommand = playerCommand;
            this.musicPublisher = musicPublisher;
        }

        public void Process() {
            var bag = DisposableBag.CreateBuilder();
            musicSelectSubscriber
                .MusicSelect
                .Subscribe(id => UniTask.Void(async () => {
                    // 選択された音楽を通知
                    playerCommand.PushCurrentMusic(id, agentCts.Token).Forget();
                    // 新しい音楽が選択されたら詳細を取得して表示する
                    var music = await musicQuery.GetMusicDataAsync(id, agentCts.Token);
                    musicPublisher.NewMusic.Publish(music);
                }))
                .AddTo(bag);
            musicSelectSubscriber
                .DeviceSelect
                .Subscribe(id => {
                    // 選択された音楽を通知
                    playerCommand.PushCurrentDevice(id, agentCts.Token).Forget();
                })
                .AddTo(bag);
            agentInnerDisposable = bag.Build();
        }
    }
}
