using Cysharp.Threading.Tasks;
using MessagePipe;
using n5y.SpotifyApi.Ui.Core.PubSub;
using n5y.SpotifyApi.Ui.Core.View;

namespace n5y.SpotifyApi.Ui.Core {
    public class MusicPlayingAgent : AgentBase {
        readonly IPlayingMusicPresentation musicPresentation;
        readonly IMusicControlPresentation controlPresentation;
        readonly ICurrentMusicSubscriber currentMusicSubscriber;
        readonly Url2Sprite url2Sprite;

        public MusicPlayingAgent(IPlayingMusicPresentation musicPresentation,
            IMusicControlPresentation controlPresentation, ICurrentMusicSubscriber currentMusicSubscriber) {
            this.musicPresentation = musicPresentation;
            this.controlPresentation = controlPresentation;
            this.currentMusicSubscriber = currentMusicSubscriber;
            url2Sprite = new Url2Sprite();
        }

        public void Process() {
            // 表示する音楽の更新
            var bag = DisposableBag.CreateBuilder();
            currentMusicSubscriber.Music.Subscribe(OnMusicUpdate).AddTo(bag);
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
