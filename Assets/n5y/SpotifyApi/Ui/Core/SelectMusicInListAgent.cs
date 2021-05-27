using UniRx;
using MessagePipe;
using n5y.SpotifyApi.Ui.Core.PubSub;
using n5y.SpotifyApi.Ui.Core.View;

namespace n5y.SpotifyApi.Ui.Core {
    public class SelectMusicInListAgent : AgentBase {
        readonly IMusicCatalogSubscriber catalog;
        readonly IMusicListPresentation listPresentation;
        readonly IMusicSelectPublisher selectPublisher;

        public SelectMusicInListAgent(IMusicCatalogSubscriber catalog, IMusicListPresentation listPresentation,
            IMusicSelectPublisher selectPublisher) {
            this.catalog = catalog;
            this.listPresentation = listPresentation;
            this.selectPublisher = selectPublisher;
        }

        public void Process() {
            var bag = DisposableBag.CreateBuilder();
            // 取得したプレイリストなど一覧情報を随時更新
            catalog.Playlist
                .Subscribe(x => {
                    listPresentation.AddPlaylist(x);
                })
                .AddTo(bag);
            catalog.Album
                .Subscribe(x => {
                    listPresentation.AddAlbum(x);
                })
                .AddTo(bag);
            catalog.Device
                .Subscribe(x => {
                    listPresentation
                        .AddDevice(x)
                        .Subscribe(selectPublisher.DeviceSelect.Publish)
                        .AddTo(agentDisposable);
                })
                .AddTo(bag);
            // 取得した音楽を随時更新
            catalog.PlaylistMusic
                .Subscribe(x => {
                    listPresentation
                        .AddPlaylistMusic(x.playlist.playlistId, x.music)
                        .Subscribe(selectPublisher.MusicSelect.Publish)
                        .AddTo(agentDisposable);
                })
                .AddTo(bag);
            catalog.AlbumMusic
                .Subscribe(x => {
                    listPresentation
                        .AddAlbumMusic(x.album.albumId, x.music)
                        .Subscribe(selectPublisher.MusicSelect.Publish)
                        .AddTo(agentDisposable);
                })
                .AddTo(bag);
            agentInnerDisposable = bag.Build();
        }
    }
}
