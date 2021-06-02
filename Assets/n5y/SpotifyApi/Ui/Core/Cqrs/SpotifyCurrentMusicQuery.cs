using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Models;

namespace n5y.SpotifyApi.Ui.Core {
    public class SpotifyCurrentMusicQuery : ICurrentMusicQuery {
        readonly ITokenProvider tokenProvider;
        readonly ITokenValidation tokenValidation;

        public SpotifyCurrentMusicQuery(ITokenProvider tokenProvider, ITokenValidation tokenValidation) {
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
    }

    public static class CurrentPlayingTrackModelToMusicDataExtension {
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
    }

    public static class ImageModelExtension {
        public static string GetBiggestImageUrl(this ImageModel[] images) {
            var validImages = FilterMultiCandidateAndWithValidRect(images, out var first);
            if (validImages == null) return first;
            var ordered = validImages.OrderBy(x => x.Height! * x.Width!);
            return ordered.LastOrDefault()?.Url;
        }

        public static string GetSmallestImageUrl(this ImageModel[] images) {
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
