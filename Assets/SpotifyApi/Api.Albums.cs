using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyApi.Models;
using UnityEngine.Networking;

namespace SpotifyApi {
    public static partial class Api {
        public static class Albums {
            public static async UniTask<AlbumModel> GetAlbumAsync(string albumId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiAlbums}/{albumId}";
                using (var req = UnityWebRequest.Get(url)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<AlbumModel>(req.downloadHandler.text);
                }
            }
            public static async UniTask<TracksPagingModel> GetAlbumTracksAsync(string albumId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiAlbums}/{albumId}/tracks";
                using (var req = UnityWebRequest.Get(url)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<TracksPagingModel>(req.downloadHandler.text);
                }
            }
        }
    }
}
