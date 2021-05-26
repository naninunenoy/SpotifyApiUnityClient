using System;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.Trigger;
using n5y.SpotifyApi.Ui.Core.View;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core {
    public class SpotifyMusicViewMain : IDisposable {
        readonly VisualElement musicViewRoot;
        readonly ISpotifyListOpen listViewOpen;
        readonly IMusicQuery musicQuery;
        readonly IPlaylistQuery playlistQuery;
        readonly IAlbumQuery albumQuery;
        readonly IDeviceQuery deviceQuery;
        readonly IPlayingMusicPresentation musicPresentation;
        readonly IMusicControlPresentation controlPresentation;
        readonly IMusicListPresentation musicListPresentation;
        readonly IMusicSubscriber musicSubscriber;
        readonly IMusicSelectPublisher musicSelectPublisher;

        VisualElement listViewRoot;
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
            // 表示する音楽の更新
            musicPlayingAgent = new MusicPlayingAgent(musicPresentation, controlPresentation, musicSubscriber);
            musicPlayingAgent.Process();
        }

        public void Dispose() {
            musicPlayingAgent?.Dispose();
            selectMusicInListAgent?.Dispose();
        }

        void OpenListView() {
            listViewRoot = listViewOpen.OpenListView();
            // リストを閉じるボタン
            var closeButton = listViewRoot.Q<Button>("closeButton");
            closeButton.clickable.clicked += OnCloseListView;
            // リストから音楽/デバイスを選択する
            selectMusicInListAgent = new SelectMusicInListAgent(musicQuery, playlistQuery, albumQuery, deviceQuery,
                musicListPresentation, musicSelectPublisher);
            selectMusicInListAgent.Process();
        }

        void OnCloseListView() {
            listViewOpen?.Close();
            selectMusicInListAgent?.Dispose();
            selectMusicInListAgent = null;
        }
    }
}
