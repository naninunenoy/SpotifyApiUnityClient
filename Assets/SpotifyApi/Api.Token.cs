using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using n5y.SpotifyApi.Models;
using UnityEngine;
using UnityEngine.Networking;

namespace n5y.SpotifyApi {
    public static partial class Api {
        public static async UniTask<TokenModel> GetTokenAsync(string accessCode, string redirectUri,
            string clientId, string clientSecret, CancellationToken cancellationToken) {
            var form = new WWWForm();
            {
                form.AddField("grant_type", "authorization_code");
                form.AddField("code", accessCode);
                form.AddField("redirect_uri", redirectUri);
            }
            using var req = UnityWebRequest.Post(Endpoints.ApiToken, form);
            var raw = $"{clientId}:{clientSecret}";
            req.SetRequestHeader("Authorization", $"Basic {Util.ToBase64(raw)}");

            cancellationToken.ThrowIfCancellationRequested();
            await req.SendWebRequest().WithCancellation(cancellationToken);

            return JsonConvert.DeserializeObject<TokenModel>(req.downloadHandler.text);
        }
        public static async UniTask<TokenModel> RefreshTokenAsync(string refreshToken,
            string clientId, string clientSecret, CancellationToken cancellationToken) {
            var form = new WWWForm();
            {
                form.AddField("grant_type", "refresh_token");
                form.AddField("refresh_token", refreshToken);
            }
            using var req = UnityWebRequest.Post(Endpoints.ApiToken, form);
            var raw = $"{clientId}:{clientSecret}";
            req.SetRequestHeader("Authorization", $"Basic {Util.ToBase64(raw)}");

            cancellationToken.ThrowIfCancellationRequested();
            await req.SendWebRequest().WithCancellation(cancellationToken);

            return JsonConvert.DeserializeObject<TokenModel>(req.downloadHandler.text);
        }
    }
}
