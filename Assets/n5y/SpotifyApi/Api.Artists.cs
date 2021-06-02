using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using n5y.SpotifyApi.Models;
using UnityEngine.Networking;

namespace n5y.SpotifyApi {
    public static partial class Api {
        public static class Artists {
            public static async UniTask<ArtistModel> GetArtistsAsync(string artistId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiArtists}/{artistId}";
                using var req = UnityWebRequest.Get(url);
                req.SetRequestHeader("Authorization", token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<ArtistModel>(req.downloadHandler.text);
            }
            public static async UniTask<AlbumsPagingModel> GetArtistsAlbumsAsync(string artistId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiAlbums}/{artistId}/albums";
                using var req = UnityWebRequest.Get(url);
                req.SetRequestHeader("Authorization", token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<AlbumsPagingModel>(req.downloadHandler.text);
            }
        }
    }
}
