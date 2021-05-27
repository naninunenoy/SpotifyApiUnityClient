using System;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.PubSub;
using n5y.SpotifyApi.Ui.Core.View;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core {
    public class SpotifyMusicViewMain : IDisposable {
        readonly VisualElement musicViewRoot;
        readonly ISpotifyListOpen listViewOpen;
        readonly IMusicQuery musicQuery;
        readonly IMusicControlCommand musicControlCommand;
        readonly IMusicCatalogSubscriber musicCatalogSubscriber;
        readonly ICurrentMusicSubscriber currentMusicSubscriber;
        readonly ICurrentMusicPublisher currentMusicPublisher;
        readonly IMusicSelectPublisher musicSelectPublisher;
        readonly IPlayingMusicPresentation musicPresentation;
        readonly IMusicControlPresentation controlPresentation;
        readonly IMusicListPresentation musicListPresentation;
        readonly IMusicViewTrigger musicViewTrigger;
        readonly IListViewTrigger listViewTrigger;

        VisualElement listViewRoot;
        CurrentMusicAgent currentMusicAgent;
        MusicControlAgent musicControlAgent;
        MusicPlayingAgent musicPlayingAgent;
        SelectMusicInListAgent selectMusicInListAgent;

        public SpotifyMusicViewMain(VisualElement musicViewRoot, ISpotifyListOpen listViewOpen) {
            this.musicViewRoot = musicViewRoot;
            this.listViewOpen = listViewOpen;
        }

        public void Process() {
            // リストを開くボタン
            var openButton = musicViewRoot.Q<Button>("openButton");
            openButton.clickable.clicked += OpenListView;
            // リストから選択された音楽の伝達
            currentMusicAgent = new CurrentMusicAgent(listViewTrigger.OnSelectMusic, musicQuery, currentMusicPublisher);
            currentMusicAgent.Process();
            // 表示する音楽の更新
            musicPlayingAgent = new MusicPlayingAgent(musicPresentation, controlPresentation, currentMusicSubscriber);
            musicPlayingAgent.Process();
            // 一時停止などの操作
            musicControlAgent = new MusicControlAgent(musicControlCommand, controlPresentation, musicViewTrigger);
            musicControlAgent.Process();
        }

        public void Dispose() {
            currentMusicAgent?.Dispose();
            musicControlAgent?.Dispose();
            musicPlayingAgent?.Dispose();
            selectMusicInListAgent?.Dispose();
        }

        void OpenListView() {
            listViewRoot = listViewOpen.OpenListView();
            // リストを閉じるボタン
            var closeButton = listViewRoot.Q<Button>("closeButton");
            closeButton.clickable.clicked += OnCloseListView;
            // リストから音楽/デバイスを選択する
            selectMusicInListAgent = new SelectMusicInListAgent(
                musicCatalogSubscriber, musicListPresentation, musicSelectPublisher);
            selectMusicInListAgent.Process();
        }

        void OnCloseListView() {
            listViewOpen?.Close();
            selectMusicInListAgent?.Dispose();
            selectMusicInListAgent = null;
        }
    }
}
