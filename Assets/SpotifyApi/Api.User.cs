using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyApi.Models;
using UnityEngine.Networking;

namespace SpotifyApi {
    public static partial class Api {
        public static async UniTask<UserModel> GetMe(ITokenProvider token,  CancellationToken cancellationToken) {
            using (var req = UnityWebRequest.Get(Endpoints.ApiMe)) {
                req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<UserModel>(req.downloadHandler.text);
            }
        }

        public static async UniTask<AlbumsResponseModel> GetMyAlbums(ITokenProvider token, CancellationToken cancellationToken) {
            using (var req = UnityWebRequest.Get(Endpoints.ApiMe + "/albums")) {
                req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<AlbumsResponseModel>(req.downloadHandler.text);
            }
        }
    }
}
