using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyApi.Models;
using UnityEngine.Networking;

namespace SpotifyApi {
    public static partial class Api {
        public static class Audio {
            public static async UniTask<AudioAnalysisModel> GetAudioAnalysisAsync(TrackId trackId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiAudioAnalysis}/{trackId.value}";
                using (var req = UnityWebRequest.Get(url)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<AudioAnalysisModel>(req.downloadHandler.text);
                }
            }

            public static async UniTask<AudioFeaturesModel> GetAudioFeaturesAsync(TrackId trackId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiAudioFeatures}/{trackId.value}";
                using (var req = UnityWebRequest.Get(url)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<AudioFeaturesModel>(req.downloadHandler.text);
                }
            }
        }
    }
}
