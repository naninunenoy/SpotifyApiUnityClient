using Cysharp.Threading.Tasks;
using MessagePipe;
using n5y.SpotifyApi.Ui.Core.Trigger;
using n5y.SpotifyApi.Ui.Core.View;

namespace n5y.SpotifyApi.Ui.Core {
    public class MusicPlayingAgent : AgentBase {
        readonly IPlayingMusicPresentation musicPresentation;
        readonly IMusicControlPresentation controlPresentation;
        readonly IMusicSubscriber musicSubscriber;
        readonly Url2Sprite url2Sprite;

        public MusicPlayingAgent(IPlayingMusicPresentation musicPresentation,
            IMusicControlPresentation controlPresentation, IMusicSubscriber musicSubscriber) {
            this.musicPresentation = musicPresentation;
            this.controlPresentation = controlPresentation;
            this.musicSubscriber = musicSubscriber;
            url2Sprite = new Url2Sprite();
        }

        public void Process() {
            // 表示する音楽の更新
            var bag = DisposableBag.CreateBuilder();
            musicSubscriber.MusicData.Subscribe(OnMusicUpdate).AddTo(bag);
            agentInnerDisposable = bag.Build();
        }

        void OnMusicUpdate(MusicData musicData) {
            // タイトルなど反映
            musicPresentation?.SetTitle(musicData.MusicName);
            musicPresentation?.SetAlbumName(musicData.AlbumName);
            musicPresentation?.SetArtistName(musicData.ArtistName);
            // urlから画像を読み込んで表示
            UniTask.Void(async () => {
                var sprite = await url2Sprite.GetSpriteFromUrl(musicData.ArtworkUrl, agentCts.Token);
                musicPresentation.SetArtwork(sprite);
            });
            // 時間をリセット
            controlPresentation.SetTime(new MusicTimeTuple(0.0F, musicData.TotalSeconds));
        }
    }
}
