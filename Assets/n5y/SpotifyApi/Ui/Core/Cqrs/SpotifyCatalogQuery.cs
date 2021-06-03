using System.Threading;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;

namespace n5y.SpotifyApi.Ui.Core.Cqrs {
    public class SpotifyCatalogQuery : IMusicCatalogQuery {
        readonly ITokenProvider tokenProvider;
        readonly ITokenValidation tokenValidation;

        public SpotifyCatalogQuery(ITokenProvider tokenProvider, ITokenValidation tokenValidation) {
            this.tokenProvider = tokenProvider;
            this.tokenValidation = tokenValidation;
        }

        static UniTask IntervalAsync() => UniTask.Delay(100);

        IUniTaskAsyncEnumerable<PlaylistTuple> IMusicCatalogQuery.GetPlaylistsAsync(CancellationToken cancellationToken) {
            return UniTaskAsyncEnumerable.Create<PlaylistTuple>(async (writer, _) => {
                await tokenValidation.ValidateAsync(cancellationToken);
                var first = await Api.GetMyPlaylistsAsync(tokenProvider, cancellationToken);
                foreach (var x in first.Items) {
                    var id = new PlaylistId(x.Id);
                    await writer.YieldAsync(new PlaylistTuple(id, x.Name));
                }

                var nextUrl = first.Next;
                while (!string.IsNullOrEmpty(nextUrl)) {
                    await IntervalAsync();
                    cancellationToken.ThrowIfCancellationRequested();
                    await tokenValidation.ValidateAsync(cancellationToken);
                    var paging = await Api.GetPlaylistsByUrlAsync(nextUrl, tokenProvider, cancellationToken);
                    foreach (var x in paging.Items) {
                        var id = new PlaylistId(x.Id);
                        await writer.YieldAsync(new PlaylistTuple(id, x.Name));
                    }

                    nextUrl = paging.Next;
                }
            });
        }

        IUniTaskAsyncEnumerable<AlbumTuple> IMusicCatalogQuery.GetAlbumsAsync(CancellationToken cancellationToken) {
            return UniTaskAsyncEnumerable.Create<AlbumTuple>(async (writer, _) => {
                await tokenValidation.ValidateAsync(cancellationToken);
                var first = await Api.GetMyAlbumsAsync(tokenProvider, cancellationToken);
                foreach (var x in first.Items) {
                    var id = new AlbumId(x.Album.Id);
                    await writer.YieldAsync(new AlbumTuple(id, x.Album.Name));
                }

                var nextUrl = first.Next;
                while (!string.IsNullOrEmpty(nextUrl)) {
                    await IntervalAsync();
                    cancellationToken.ThrowIfCancellationRequested();
                    await tokenValidation.ValidateAsync(cancellationToken);
                    var paging = await Api.GetSavedAlbumsByUrlAsync(nextUrl, tokenProvider, cancellationToken);
                    foreach (var x in paging.Items) {
                        var id = new AlbumId(x.Album.Id);
                        await writer.YieldAsync(new AlbumTuple(id, x.Album.Name));
                    }

                    nextUrl = paging.Next;
                }
            });
        }

        IUniTaskAsyncEnumerable<DeviceTuple> IMusicCatalogQuery.GetDevicesAsync(CancellationToken cancellationToken) {
            return UniTaskAsyncEnumerable.Create<DeviceTuple>(async (writer, _) => {
                await tokenValidation.ValidateAsync(cancellationToken);
                var list = await Api.GetDevicesAsync(tokenProvider, cancellationToken);
                foreach (var x in list.Devices) {
                    var id = new DeviceId(x.Id);
                    await writer.YieldAsync(new DeviceTuple(id, x.Name));
                }
            });
        }

        IUniTaskAsyncEnumerable<MusicTuple> IMusicCatalogQuery.GetMusicsAsync(PlaylistId playlistId,
            CancellationToken cancellationToken) {
            return UniTaskAsyncEnumerable.Create<MusicTuple>(async (writer, _) => {
                await tokenValidation.ValidateAsync(cancellationToken);
                var first = await Api.GetPlaylistTracksAsync(playlistId.Identifier, tokenProvider,
                    cancellationToken);
                foreach (var x in first.Items) {
                    var id = new MusicId(x.Track.Id);
                    await writer.YieldAsync(new MusicTuple(id, x.Track.Name));
                }

                var nextUrl = first.Next;
                while (!string.IsNullOrEmpty(nextUrl)) {
                    await IntervalAsync();
                    cancellationToken.ThrowIfCancellationRequested();
                    await tokenValidation.ValidateAsync(cancellationToken);
                    var paging = await Api.GetPlaylistTracksByUrlAsync(nextUrl, tokenProvider, cancellationToken);
                    foreach (var x in paging.Items) {
                        var id = new MusicId(x.Track.Id);
                        await writer.YieldAsync(new MusicTuple(id, x.Track.Name));
                    }

                    nextUrl = paging.Next;
                }
            });
        }

        IUniTaskAsyncEnumerable<MusicTuple> IMusicCatalogQuery.GetMusicsAsync(AlbumId albumId,
            CancellationToken cancellationToken) {
            return UniTaskAsyncEnumerable.Create<MusicTuple>(async (writer, _) => {
                await tokenValidation.ValidateAsync(cancellationToken);
                var first = await Api.GetAlbumTracksAsync(albumId.Identifier, tokenProvider, cancellationToken);
                foreach (var x in first.Items) {
                    var id = new MusicId(x.Id);
                    await writer.YieldAsync(new MusicTuple(id, x.Name));
                }

                var nextUrl = first.Next;
                while (!string.IsNullOrEmpty(nextUrl)) {
                    await IntervalAsync();
                    cancellationToken.ThrowIfCancellationRequested();
                    await tokenValidation.ValidateAsync(cancellationToken);
                    var paging = await Api.GetAlbumTracksByUrlAsync(nextUrl, tokenProvider, cancellationToken);
                    foreach (var x in paging.Items) {
                        var id = new MusicId(x.Id);
                        await writer.YieldAsync(new MusicTuple(id, x.Name));
                    }

                    nextUrl = paging.Next;
                }
            });
        }
    }
}
