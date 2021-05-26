using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MessagePipe;
using n5y.SpotifyApi.Ui.Core.Trigger;
using n5y.SpotifyApi.Ui.Core.View;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core {
    public class SpotifyMusicViewMain : IDisposable {
        readonly VisualElement musicViewRoot;
        readonly ISpotifyListOpen listViewOpen;
        readonly IPlayingMusicPresentation musicPresentation;
        readonly IMusicControlPresentation controlPresentation;
        readonly IMusicSubscriber musicSubscriber;
        readonly Url2Sprite url2Sprite;

        VisualElement listViewRoot;
        IDisposable musicViewDisposable;
        CancellationTokenSource musicViewCts;
        IDisposable listViewDisposable;

        public SpotifyMusicViewMain(VisualElement musicViewRoot, ISpotifyListOpen listViewOpen) {
            this.musicViewRoot = musicViewRoot;
            this.listViewOpen = listViewOpen;
            url2Sprite = new Url2Sprite();
        }

        public void Process() {
            // リストを開くボタン
            var openButton = musicViewRoot.Q<Button>("openButton");
            openButton.clickable.clicked += OpenListView;
            // 表示する音楽の更新
            var bag = DisposableBag.CreateBuilder();
            musicSubscriber.MusicDataAsync.Subscribe(OnMusicUpdate).AddTo(bag);
            musicViewDisposable = bag.Build();
        }

        public void Dispose() {
            musicViewCts?.Cancel();
            musicViewDisposable?.Dispose();
        }

        void OpenListView() {
            listViewRoot = listViewOpen.OpenListView();
            // リストを閉じるボタン
            var closeButton = listViewRoot.Q<Button>("closeButton");
            closeButton.clickable.clicked += listViewOpen.Close;
        }

        void OnMusicUpdate(MusicData musicData) {
            // タイトルなど反映
            musicPresentation?.SetTitle(musicData.MusicName);
            musicPresentation?.SetAlbumName(musicData.AlbumName);
            musicPresentation?.SetArtistName(musicData.ArtistName);
            // urlから画像を読み込んで表示
            UniTask.Void(async () => {
                var sprite = await url2Sprite.GetSpriteFromUrl(musicData.ArtworkUrl, musicViewCts.Token);
                musicPresentation.SetArtwork(sprite);
            });
            // 時間をリセット
            controlPresentation.SetTime(new MusicTimeTuple(0.0F, musicData.TotalSeconds));
        }
    }
}
