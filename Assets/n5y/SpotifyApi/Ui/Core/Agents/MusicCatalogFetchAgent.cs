using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.PubSub;
using n5y.SpotifyApi.Ui.Core.View;
using UniRx;

namespace n5y.SpotifyApi.Ui.Core {
    public class MusicCatalogFetchAgent : AgentBase {
        readonly IMusicCatalogPublisher catalogPublisher;
        readonly IMusicSelectPublisher musicSelectPublisher;
        readonly IMusicCatalogQuery catalogQuery;
        readonly IListViewTrigger listViewTrigger;

        public MusicCatalogFetchAgent(IMusicCatalogPublisher catalogPublisher,
            IMusicSelectPublisher musicSelectPublisher, IMusicCatalogQuery catalogQuery,
            IListViewTrigger listViewTrigger) {
            this.catalogPublisher = catalogPublisher;
            this.musicSelectPublisher = musicSelectPublisher;
            this.catalogQuery = catalogQuery;
            this.listViewTrigger = listViewTrigger;
        }

        public void Process() {
            // プレイリスト一覧などの読み込みをキックし、読み込みごとに通知する
            listViewTrigger.OnPlaylistSelect
                .Subscribe(_ => {
                    catalogQuery
                        .GetPlaylistsAsync(agentCts.Token)
                        .ForEachAsync(catalogPublisher.Playlist.Publish, agentCts.Token)
                        .Forget();
                })
                .AddTo(agentDisposable);
            listViewTrigger.OnAlbumSelect
                .Subscribe(_ => {
                    catalogQuery
                        .GetAlbumsAsync(agentCts.Token)
                        .ForEachAsync(catalogPublisher.Album.Publish, agentCts.Token)
                        .Forget();
                })
                .AddTo(agentDisposable);
            listViewTrigger.OnDeviceSelect
                .Subscribe(_ => {
                    catalogQuery
                        .GetDevicesAsync(agentCts.Token)
                        .ForEachAsync(catalogPublisher.Device.Publish, agentCts.Token)
                        .Forget();
                })
                .AddTo(agentDisposable);
            // プレイリスト中の音楽読み込みをキックし、読み込みごとに通知する
            listViewTrigger.OnDecidePlaylist
                .Subscribe(id => {
                    catalogQuery
                        .GetMusicsAsync(id, agentCts.Token)
                        .ForEachAsync(x => {
                            catalogPublisher.PlaylistMusic.Publish(new PlaylistMusicTuple(id, x));
                        }, agentCts.Token)
                        .Forget();
                })
                .AddTo(agentDisposable);
            listViewTrigger.OnDecideAlbum
                .Subscribe(id => {
                    catalogQuery
                        .GetMusicsAsync(id, agentCts.Token)
                        .ForEachAsync(x => {
                            catalogPublisher.AlbumMusic.Publish(new AlbumMusicTuple(id, x));
                        }, agentCts.Token)
                        .Forget();
                })
                .AddTo(agentDisposable);
            // プレイリスト/アルバムの中から選択された音楽を通知
            listViewTrigger.OnDecideMusic
                .Subscribe(musicSelectPublisher.MusicSelect.Publish)
                .AddTo(agentDisposable);
        }
    }
}
