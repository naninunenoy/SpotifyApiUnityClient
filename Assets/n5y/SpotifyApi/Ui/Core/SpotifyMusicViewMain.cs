using System;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.PubSub;
using n5y.SpotifyApi.Ui.Core.View;
using UniRx;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core {
    public class SpotifyMusicViewMain : IDisposable {
        readonly IEnvironmentProvider env;
        readonly IRefreshTokenStorage refreshToken;
        readonly VisualElement musicViewRoot;
        readonly ISpotifyListOpen listViewOpen;
        readonly IMusicQuery musicQuery;
        readonly IMusicCatalogQuery musicCatalogQuery;
        readonly ICurrentMusicQuery currentMusicQuery;
        readonly IMusicControlCommand musicControlCommand;
        readonly ICurrentPlayerCommand playerCommand;
        readonly IMusicCatalogSubscriber musicCatalogSubscriber;
        readonly IMusicCatalogPublisher musicCatalogPublisher;
        readonly ICurrentMusicSubscriber currentMusicSubscriber;
        readonly ICurrentMusicPublisher currentMusicPublisher;
        readonly IMusicSelectPublisher musicSelectPublisher;
        readonly IPlayingMusicPresentation musicPresentation;
        readonly IMusicControlPresentation controlPresentation;
        readonly IMusicListPresentation musicListPresentation;
        readonly IMusicViewTrigger musicViewTrigger;
        readonly IListViewTrigger listViewTrigger;

        VisualElement listViewRoot;
        AuthorizeAgent authorizeAgent;
        CurrentPlayerAgent currentPlayerAgent;
        MusicControlAgent musicControlAgent;
        MusicPlayingAgent musicPlayingAgent;
        MusicSyncAgent musicSyncAgent;
        SelectMusicInListAgent selectMusicInListAgent;
        MusicCatalogFetchAgent catalogFetchAgent;

        public SpotifyMusicViewMain(VisualElement musicViewRoot, ISpotifyListOpen listViewOpen,
            IEnvironmentProvider env, IRefreshTokenStorage refreshToken) {
            this.musicViewRoot = musicViewRoot;
            this.listViewOpen = listViewOpen;
            this.env = env;
            this.refreshToken = refreshToken;
        }

        public void Process() {
            // リストを開くボタン
            var openButton = musicViewRoot.Q<Button>("openButton");
            openButton.clickable.clicked += OpenListView;
            // リストから選択された音楽の伝達
            currentPlayerAgent = new CurrentPlayerAgent(listViewTrigger, musicQuery, playerCommand, currentMusicPublisher);
            currentPlayerAgent.Process();
            // 表示する音楽の更新
            musicPlayingAgent = new MusicPlayingAgent(musicPresentation, controlPresentation, currentMusicSubscriber);
            musicPlayingAgent.Process();
            // 一時停止などの操作
            musicControlAgent = new MusicControlAgent(musicControlCommand, controlPresentation, musicViewTrigger);
            musicControlAgent.Process();
            // 再生音楽の同期
            var oneSecondsSync = Observable.Interval(TimeSpan.FromSeconds(1)).AsUnitObservable();
            musicSyncAgent = new MusicSyncAgent(oneSecondsSync, currentMusicQuery, currentMusicPublisher,
                controlPresentation);
            musicSyncAgent.Process();
        }

        public void Dispose() {
            currentPlayerAgent?.Dispose();
            musicControlAgent?.Dispose();
            musicPlayingAgent?.Dispose();
            musicSyncAgent?.Dispose();
            selectMusicInListAgent?.Dispose();
            catalogFetchAgent?.Dispose();
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
            // 選択されたプレイリストなどの情報を取得する
            catalogFetchAgent = new MusicCatalogFetchAgent(musicCatalogPublisher, musicSelectPublisher,
                musicCatalogQuery, listViewTrigger);
            catalogFetchAgent.Process();
        }

        void OnCloseListView() {
            listViewOpen?.Close();
            selectMusicInListAgent?.Dispose();
            selectMusicInListAgent = null;
            catalogFetchAgent?.Dispose();
            catalogFetchAgent = null;
        }
    }
}
