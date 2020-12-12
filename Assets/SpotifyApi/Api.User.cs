using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyApi.Models;
using UnityEngine.Networking;

namespace SpotifyApi {
    public static partial class Api {
        public static async UniTask<UserModel> GetMeAsync(ITokenProvider token,  CancellationToken cancellationToken) {
            using (var req = UnityWebRequest.Get(Endpoints.ApiMe)) {
                req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<UserModel>(req.downloadHandler.text);
            }
        }

        public static async UniTask<SavedAlbumsPagingModel> GetMyAlbumsAsync(ITokenProvider token, CancellationToken cancellationToken) {
            using (var req = UnityWebRequest.Get(Endpoints.ApiMyAlbums)) {
                req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<SavedAlbumsPagingModel>(req.downloadHandler.text);
            }
        }

        public static async UniTask<PlaylistsPagingModel> GetMyPlaylistsAsync(ITokenProvider token, CancellationToken cancellationToken) {
            using (var req = UnityWebRequest.Get(Endpoints.ApiMyPlaylist)) {
                req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<PlaylistsPagingModel>(req.downloadHandler.text);
            }
        }
    }
}
