using System;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core {
    public class SpotifyMusicViewMain : IDisposable {
        readonly VisualElement musicViewRoot;
        readonly ISpotifyListOpen listViewOpen;
        VisualElement listViewRoot;

        public SpotifyMusicViewMain(VisualElement musicViewRoot, ISpotifyListOpen listViewOpen) {
            this.musicViewRoot = musicViewRoot;
            this.listViewOpen = listViewOpen;
        }

        public void Process() {
            // リストを開くボタン
            var openButton = musicViewRoot.Q<Button>("openButton");
            openButton.clickable.clicked += OpenListView;
        }

        public void Dispose() {

        }

        void OpenListView() {
            listViewRoot = listViewOpen.OpenListView();
            // リストを閉じるボタン
            var closeButton = listViewRoot.Q<Button>("closeButton");
            closeButton.clickable.clicked += listViewOpen.Close;
        }
    }
}
