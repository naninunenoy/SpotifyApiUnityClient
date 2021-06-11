using System;
using Cysharp.Threading.Tasks;
using MessagePipe;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.PubSub;
using n5y.SpotifyApi.Ui.Core.View;
using UniRx;
using UnityEngine;
using UnityEngine.UIElements;

namespace n5y.SpotifyApi.Ui.Core {
    public class SpotifyMusicViewMain : IDisposable {
        readonly VisualElement musicViewRoot;
        readonly ISpotifyListOpen listViewOpen;
        readonly IEnvironmentProvider env;
        readonly IRefreshTokenStorage refreshToken;
        readonly CompositeDisposable compositeDisposable;

        ITokenProvider tokenProvider = new EmptyTokenProvider();
        ITokenValidation tokenValidation = new EmptyITokenValidation();
        IMusicQuery musicQuery;
        IMusicCatalogQuery musicCatalogQuery;
        ICurrentMusicQuery currentMusicQuery;
        IMusicControlCommand musicControlCommand;
        ICurrentPlayerCommand playerCommand;
        IMusicCatalogSubscriber musicCatalogSubscriber;
        IMusicCatalogPublisher musicCatalogPublisher;
        ICurrentMusicSubscriber currentMusicSubscriber;
        ICurrentMusicPublisher currentMusicPublisher;
        IMusicSelectPublisher musicSelectPublisher;
        IMusicSelectSubscriber musicSelectSubscriber;
        IPlayingMusicPresentation musicPresentation;
        IMusicControlPresentation controlPresentation;
        IMusicListPresentation musicListPresentation;
        IMusicViewTrigger musicViewTrigger;
        IListViewTrigger listViewTrigger;

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

        public async void Process() {
            // 初回の認証
            await FirstAuthAsync();
            // 初期化
            InitializeCqrs();
            InitializePubSub();
            InitializeMusicView();
            // リストを開くボタン
            var openButton = musicViewRoot.Q<Button>("openButton");
            openButton.clickable.clicked += OpenListView;
            // リストから選択された音楽の伝達
            currentPlayerAgent = new CurrentPlayerAgent(musicSelectSubscriber, musicQuery, playerCommand, currentMusicPublisher);
            currentPlayerAgent.Process();
            // 表示する音楽の更新
            musicPlayingAgent = new MusicPlayingAgent(musicPresentation, controlPresentation, currentMusicSubscriber);
            musicPlayingAgent.Process();
            // 一時停止などの操作
            musicControlAgent = new MusicControlAgent(currentMusicSubscriber, musicControlCommand, controlPresentation, musicViewTrigger);
            musicControlAgent.Process();
            // 再生音楽の同期
            var oneSecondsSync = Observable.Interval(TimeSpan.FromSeconds(1)).AsUnitObservable();
            musicSyncAgent = new MusicSyncAgent(oneSecondsSync, currentMusicQuery, currentMusicPublisher,
                controlPresentation);
            musicSyncAgent.Process();
        }

        public void Dispose() {
            authorizeAgent?.Dispose();
            currentPlayerAgent?.Dispose();
            musicControlAgent?.Dispose();
            musicPlayingAgent?.Dispose();
            musicSyncAgent?.Dispose();
            selectMusicInListAgent?.Dispose();
            catalogFetchAgent?.Dispose();
            compositeDisposable?.Clear();
        }

        void OpenListView() {
            listViewRoot = listViewOpen.OpenListView();
            InitializeListView();
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

        async UniTask FirstAuthAsync() {
            authorizeAgent = new AuthorizeAgent(env, refreshToken);
            try {
                var tuple = await authorizeAgent.TryFirstAuthorize();
                tokenProvider = tuple.TokenProvider;
                tokenValidation = tuple.TokenValidation;
            } catch (Exception e) {
                Debug.LogWarning(e.Message);
            }
        }

        void InitializeCqrs() {
            var spotifyMusicQuery =  new SpotifyMusicQuery(tokenProvider, tokenValidation);
            musicQuery = spotifyMusicQuery;
            currentMusicQuery = spotifyMusicQuery;
            musicCatalogQuery = new SpotifyCatalogQuery(tokenProvider, tokenValidation);
            musicControlCommand = new SpotifyControlCommand(tokenProvider, tokenValidation);
            playerCommand = new SpotifyPlayerCommand(tokenProvider, tokenValidation);
        }

        void InitializePubSub() {
            var builder = new BuiltinContainerBuilder();
            builder.AddMessagePipe();
            builder.AddMessageBroker<MusicData>();
            builder.AddMessageBroker<PlaylistTuple>();
            builder.AddMessageBroker<AlbumTuple>();
            builder.AddMessageBroker<DeviceTuple>();
            builder.AddMessageBroker<PlaylistMusicTuple>();
            builder.AddMessageBroker<AlbumMusicTuple>();
            builder.AddMessageBroker<MusicId>();
            builder.AddMessageBroker<DeviceId>();
            var resolver = builder.BuildServiceProvider();
            GlobalMessagePipe.SetProvider(resolver);

            var publisher = new MusicMessagePipePublisher(resolver);
            musicCatalogPublisher = publisher;
            currentMusicPublisher = publisher;
            musicSelectPublisher = publisher;
            var subscriber = new MusicMessagePipeSubscriber(resolver);
            musicCatalogSubscriber = subscriber;
            currentMusicSubscriber = subscriber;
            musicSelectSubscriber = subscriber;
        }

        void InitializeMusicView() {
            var view = new MusicPlayerVisualElement(musicViewRoot, compositeDisposable);
            musicPresentation = view;
            controlPresentation = view;
            musicViewTrigger = view;
        }

        void InitializeListView() {
            var view = new MusicListVisualElement(listViewRoot, compositeDisposable);
            musicListPresentation = view;
            listViewTrigger = view;
        }
    }
}
