using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Models;
using n5y.SpotifyApi.Ui.Core.Cqrs;

namespace n5y.SpotifyApi.Ui.Core {
    public class SpotifyMusicQuery : IMusicQuery, ICurrentMusicQuery {
        readonly ITokenProvider tokenProvider;
        readonly ITokenValidation tokenValidation;

        public SpotifyMusicQuery(ITokenProvider tokenProvider, ITokenValidation tokenValidation) {
            this.tokenProvider = tokenProvider;
            this.tokenValidation = tokenValidation;
        }

        async UniTask<CurrentMusic> ICurrentMusicQuery.GetCurrentMusic(CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            var current = await Api.Player.GetCurrentlyPlayingAsync(tokenProvider, cancellationToken);
            return current == null
                ? CurrentMusic.Empty()
                : new CurrentMusic(current.IsPlaying, current.ProgressMs, current.ToMusicData());
        }

        async UniTask<MusicData> IMusicQuery.GetMusicDataAsync(MusicId musicId, CancellationToken cancellationToken) {
            await tokenValidation.ValidateAsync(cancellationToken);
            var track = await Api.GetTruckAsync(musicId.Identifier, tokenProvider, cancellationToken);
            return track.ToMusicData();
        }
    }

    public static class SpotifyModelExtension {
        public static MusicData ToMusicData(this TrackModel track) {
            if (track == null) return MusicData.Empty();
            var name = track.Name;
            var albumName = track.Album?.Name ?? "???";
            var artistName = track.Artists?.FirstOrDefault()?.Name ?? "???";
            var imageUrl = track.Album?.Images.GetBiggestImageUrl() ?? "";
            float seconds = track.DurationMs;
            return new MusicData(name, albumName, artistName, imageUrl, seconds);
        }
        public static MusicData ToMusicData(this CurrentlyPlayingTrackModel track) {
            var item = track.Item;
            if (item == null) return MusicData.Empty();
            var name = item.Name;
            var albumName = item.Album?.Name ?? "???";
            var artistName = item.Artists?.FirstOrDefault()?.Name ?? "???";
            var imageUrl = item.Album?.Images.GetBiggestImageUrl() ?? "";
            float seconds = item.DurationMs;
            return new MusicData(name, albumName, artistName, imageUrl, seconds);
        }

        static string GetBiggestImageUrl(this ImageModel[] images) {
            var validImages = FilterMultiCandidateAndWithValidRect(images, out var first);
            if (validImages == null) return first;
            var ordered = validImages.OrderBy(x => x.Height! * x.Width!);
            return ordered.LastOrDefault()?.Url;
        }

        static string GetSmallestImageUrl(this ImageModel[] images) {
            var validImages = FilterMultiCandidateAndWithValidRect(images, out var first);
            if (validImages == null) return first;
            var ordered = validImages.OrderBy(x => x.Height! * x.Width!);
            return ordered.FirstOrDefault()?.Url;
        }

        static IEnumerable<ImageModel> FilterMultiCandidateAndWithValidRect(ImageModel[] images, out string candidate) {
            if (images.Length == 0) {
                candidate = null;
                return null;
            }

            if (images.Length == 1) {
                candidate = images[0].Url;
                return null;
            }
            // 画像のサイズは null の場合があるのでバリデーション
            var validImages = images.Where(x => x.Width != null && x.Height != null).ToArray();
            if (validImages.Length == 0) {
                candidate = images[0].Url;
                return null;
            }

            candidate = "";
            return validImages;
        }
    }
}
