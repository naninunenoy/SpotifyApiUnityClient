using System;
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

        VisualElement listViewRoot;
        MusicPlayingAgent musicPlayingAgent;

        public SpotifyMusicViewMain(VisualElement musicViewRoot, ISpotifyListOpen listViewOpen) {
            this.musicViewRoot = musicViewRoot;
            this.listViewOpen = listViewOpen;
        }

        public void Process() {
            // リストを開くボタン
            var openButton = musicViewRoot.Q<Button>("openButton");
            openButton.clickable.clicked += OpenListView;
            // 表示する音楽の更新
            musicPlayingAgent = new MusicPlayingAgent(musicPresentation, controlPresentation, musicSubscriber);
            musicPlayingAgent.Process();
        }

        public void Dispose() {
            musicPlayingAgent?.Dispose();
        }

        void OpenListView() {
            listViewRoot = listViewOpen.OpenListView();
            // リストを閉じるボタン
            var closeButton = listViewRoot.Q<Button>("closeButton");
            closeButton.clickable.clicked += listViewOpen.Close;
        }
    }
}
