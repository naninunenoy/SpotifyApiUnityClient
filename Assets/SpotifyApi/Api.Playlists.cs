using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using n5y.SpotifyApi.Models;
using UnityEngine.Networking;

namespace n5y.SpotifyApi {
    public static partial class Api {
        public static class Playlists {
            public static async UniTask<PlaylistsPagingModel> GetPlaylistAsync(string playlistId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiPlaylist}/{playlistId}";
                using var req = UnityWebRequest.Get(url);
                req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<PlaylistsPagingModel>(req.downloadHandler.text);
            }
            public static async UniTask<PlaylistTrackPagingModel> GetPlaylistTracksAsync(string playlistId, ITokenProvider token,
                CancellationToken cancellationToken) {
                var url = $"{Endpoints.ApiPlaylist}/{playlistId}/tracks";
                using var req = UnityWebRequest.Get(url);
                req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                cancellationToken.ThrowIfCancellationRequested();
                await req.SendWebRequest().WithCancellation(cancellationToken);

                return JsonConvert.DeserializeObject<PlaylistTrackPagingModel>(req.downloadHandler.text);
            }
        }
    }
}
