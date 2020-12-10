using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyApi.Models;
using UnityEngine.Networking;

namespace SpotifyApi {
    public static partial class Api {
        public static class Artists {
            public static async UniTask<ArtistModel> GetArtistsAsync(ArtistId artistId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiArtists}/{artistId.value}";
                using (var req = UnityWebRequest.Get(url)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<ArtistModel>(req.downloadHandler.text);
                }
            }
            public static async UniTask<AlbumsPagingModel> GetArtistsAlbumsAsync(ArtistId artistId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiAlbums}/{artistId.value}/albums";
                using (var req = UnityWebRequest.Get(url)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<AlbumsPagingModel>(req.downloadHandler.text);
                }
            }
        }
    }
}
