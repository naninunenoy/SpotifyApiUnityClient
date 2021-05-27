using UniRx;
using MessagePipe;
using n5y.SpotifyApi.Ui.Core.Cqrs;
using n5y.SpotifyApi.Ui.Core.View;

namespace n5y.SpotifyApi.Ui.Core {
    public class SelectMusicInListAgent : AgentBase {
        readonly IMusicQuery musicQuery;
        readonly IPlaylistQuery playlistQuery;
        readonly IAlbumQuery albumQuery;
        readonly IDeviceQuery deviceQuery;
        readonly IMusicListPresentation listPresentation;
        readonly IMusicSelectPublisher selectPublisher;

        public SelectMusicInListAgent(IMusicQuery musicQuery, IPlaylistQuery playlistQuery, IAlbumQuery albumQuery,
            IDeviceQuery deviceQuery, IMusicListPresentation listPresentation,
            IMusicSelectPublisher selectPublisher) {
            this.musicQuery = musicQuery;
            this.playlistQuery = playlistQuery;
            this.albumQuery = albumQuery;
            this.deviceQuery = deviceQuery;
            this.listPresentation = listPresentation;
            this.selectPublisher = selectPublisher;
        }

        public void Process() {
            var bag = DisposableBag.CreateBuilder();
            // 取得したプレイリストなど一覧情報を随時更新
            playlistQuery.Playlist
                .Subscribe(x => {
                    listPresentation.AddPlaylist(x);
                })
                .AddTo(bag);
            albumQuery.Album
                .Subscribe(x => {
                    listPresentation.AddAlbum(x);
                })
                .AddTo(bag);
            deviceQuery.Device
                .Subscribe(x => {
                    listPresentation
                        .AddDevice(x)
                        .Subscribe(selectPublisher.DeviceSelect.Publish)
                        .AddTo(agentDisposable);
                })
                .AddTo(bag);
            // 取得した音楽を随時更新
            musicQuery.PlaylistMusic
                .Subscribe(x => {
                    var (playlist, music) = x;
                    listPresentation
                        .AddPlaylistMusic(playlist.playlistId, music)
                        .Subscribe(selectPublisher.MusicSelect.Publish)
                        .AddTo(agentDisposable);
                })
                .AddTo(bag);
            musicQuery.AlbumMusic
                .Subscribe(x => {
                    var (album, music) = x;
                    listPresentation
                        .AddAlbumMusic(album.albumId, music)
                        .Subscribe(selectPublisher.MusicSelect.Publish)
                        .AddTo(agentDisposable);
                })
                .AddTo(bag);
            agentInnerDisposable = bag.Build();
        }
    }
}