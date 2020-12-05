using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using SpotifyApi.Models;
using UnityEngine;
using UnityEngine.Networking;

namespace SpotifyApi {
    public static partial class Api {
        public static async UniTask<UserModel> GetMe(ITokenProvider token,  CancellationToken cancellationToken) {
            using (var req = UnityWebRequest.Get(Endpoints.ApiMe)) {
                var raw = $"{Environment.ClientId}:{Environment.ClientSecret}";
                req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonUtility.FromJson<UserModel>(req.downloadHandler.text);
            }
        }
    }
}
