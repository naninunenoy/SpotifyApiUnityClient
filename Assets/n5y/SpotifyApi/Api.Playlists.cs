using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using n5y.SpotifyApi.Models;
using UnityEngine.Networking;

namespace n5y.SpotifyApi {
    public static partial class Api {
        public static async UniTask<PlaylistsPagingModel> GetPlaylistAsync(string playlistId, ITokenProvider token,
            CancellationToken cancellationToken) {
            var url = $"{Endpoints.ApiPlaylists}/{playlistId}";
            using var req = UnityWebRequest.Get(url);
            req.SetRequestHeader("Authorization", token.GetAuthorizationHeaderValue());

            cancellationToken.ThrowIfCancellationRequested();
            await req.SendWebRequest().WithCancellation(cancellationToken);

            return JsonConvert.DeserializeObject<PlaylistsPagingModel>(req.downloadHandler.text);
        }

        public static async UniTask<PlaylistTrackPagingModel> GetPlaylistTracksAsync(string playlistId,
            ITokenProvider token,
            CancellationToken cancellationToken) {
            var url = $"{Endpoints.ApiPlaylists}/{playlistId}/tracks";
            using var req = UnityWebRequest.Get(url);
            req.SetRequestHeader("Authorization", token.GetAuthorizationHeaderValue());

            cancellationToken.ThrowIfCancellationRequested();
            await req.SendWebRequest().WithCancellation(cancellationToken);

            return JsonConvert.DeserializeObject<PlaylistTrackPagingModel>(req.downloadHandler.text);
        }

        public static async UniTask<PlaylistsPagingModel> GetPlaylistsByUrlAsync(string url,
            ITokenProvider token, CancellationToken cancellationToken) {
            using var req = UnityWebRequest.Get(url);
            req.SetRequestHeader("Authorization", token.GetAuthorizationHeaderValue());

            cancellationToken.ThrowIfCancellationRequested();
            await req.SendWebRequest().WithCancellation(cancellationToken);

            return JsonConvert.DeserializeObject<PlaylistsPagingModel>(req.downloadHandler.text);
        }

        public static async UniTask<PlaylistTrackPagingModel> GetPlaylistTracksByUrlAsync(string url,
            ITokenProvider token, CancellationToken cancellationToken) {
            using var req = UnityWebRequest.Get(url);
            req.SetRequestHeader("Authorization", token.GetAuthorizationHeaderValue());

            cancellationToken.ThrowIfCancellationRequested();
            await req.SendWebRequest().WithCancellation(cancellationToken);

            return JsonConvert.DeserializeObject<PlaylistTrackPagingModel>(req.downloadHandler.text);
        }
    }
}
