using System.Threading;
using Cysharp.Threading.Tasks;
using n5y.SpotifyApi.Models;
using Newtonsoft.Json;
using UnityEngine.Networking;

namespace n5y.SpotifyApi
{
    public static partial class Api {
        public static async UniTask<TrackModel> GetTruckAsync(string truckId, ITokenProvider token,
            CancellationToken cancellationToken) {
            var url = $"{Endpoints.ApiAlbums}/{truckId}";
            using var req = UnityWebRequest.Get(url);
            req.SetRequestHeader("Authorization", token.GetAuthorizationHeaderValue());

            cancellationToken.ThrowIfCancellationRequested();
            await req.SendWebRequest().WithCancellation(cancellationToken);

            return JsonConvert.DeserializeObject<TrackModel>(req.downloadHandler.text);
        }
    }
}
