using System.Threading;
using Cysharp.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyApi.Models;
using UnityEngine.Networking;

namespace SpotifyApi {
    public static partial class Api {
        public static class Player {
            const string emptyBody = "{}";
            public static async UniTask PostQueueAsync(string uri, ITokenProvider token,  CancellationToken cancellationToken) {
                var query = $"&uri={uri}";
                using (var req = UnityWebRequest.Post(Endpoints.ApiMyPlayerQueue + query, "")) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask<UserModel> GetDevicesAsync(ITokenProvider token,  CancellationToken cancellationToken) {
                using (var req = UnityWebRequest.Get(Endpoints.ApiMyPlayerDevices)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<UserModel>(req.downloadHandler.text);
                }
            }
            public static async UniTask<PlayerModel> GetPlayerAsync(ITokenProvider token,  CancellationToken cancellationToken) {
                using (var req = UnityWebRequest.Get(Endpoints.ApiMyPlayer)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<PlayerModel>(req.downloadHandler.text);
                }
            }
            public static async UniTask PutPlayerAsync(DeviceId deviceId, ITokenProvider token,  CancellationToken cancellationToken) {
                var body = "{\"device_ids\":\"" + deviceId.value + "\"}";
                using (var req = UnityWebRequest.Put(Endpoints.ApiMyPlayer, body)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask<RecentlyPlayedTrackModel> GetRecentlyPlayedAsync(ITokenProvider token,  CancellationToken cancellationToken) {
                using (var req = UnityWebRequest.Get(Endpoints.ApiMyPlayerRecentlyPlayed)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<RecentlyPlayedTrackModel>(req.downloadHandler.text);
                }
            }
            public static async UniTask<CurrentlyPlayingTrackModel> GetCurrentlyPlayingAsync(ITokenProvider token,  CancellationToken cancellationToken) {
                using (var req = UnityWebRequest.Get(Endpoints.ApiMyPlayerCurrentlyPlaying)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);

                    return JsonConvert.DeserializeObject<CurrentlyPlayingTrackModel>(req.downloadHandler.text);
                }
            }
            public static async UniTask PutPauseAsync(ITokenProvider token,  CancellationToken cancellationToken) {
                using (var req = UnityWebRequest.Put(Endpoints.ApiMyPlayerPause, emptyBody)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask PutSeekAsync(int positionMs, ITokenProvider token,  CancellationToken cancellationToken) {
                var query = $"&position_ms={positionMs}";
                using (var req = UnityWebRequest.Put(Endpoints.ApiMyPlayerSeek + query, emptyBody)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask PutRepeatAsync(RepeatState repeatState, ITokenProvider token,  CancellationToken cancellationToken) {
                var query = $"&state={repeatState.Value()}";
                using (var req = UnityWebRequest.Put(Endpoints.ApiMyPlayerRepeat + query, emptyBody)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask PutRepeatAsync(int volumePercent, ITokenProvider token,  CancellationToken cancellationToken) {
                var query = $"&volume_percent={volumePercent}";
                using (var req = UnityWebRequest.Put(Endpoints.ApiMyPlayerVolume + query, emptyBody)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask PostNextAsync(ITokenProvider token,  CancellationToken cancellationToken) {
                using (var req = UnityWebRequest.Post(Endpoints.ApiMyPlayerNext, emptyBody)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask PostPreviousAsync(ITokenProvider token,  CancellationToken cancellationToken) {
                using (var req = UnityWebRequest.Post(Endpoints.ApiMyPlayerPrevious, emptyBody)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask PutPlayAsync(string contextUri, ITokenProvider token,  CancellationToken cancellationToken) {
                var body = string.IsNullOrEmpty(contextUri) ? emptyBody : "{\"context_uri\":\"" + contextUri + "\"}";
                using (var req = UnityWebRequest.Put(Endpoints.ApiMyPlayerPlay, body)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
            public static async UniTask PutShuffleAsync(bool shuffle, ITokenProvider token,  CancellationToken cancellationToken) {
                var query = $"&state={shuffle}";
                using (var req = UnityWebRequest.Put(Endpoints.ApiMyPlayerShuffle + "query", emptyBody)) {
                    req.SetRequestHeader("Authorization", token.Token.GetAuthorizationHeaderValue());

                    cancellationToken.ThrowIfCancellationRequested();
                    await req.SendWebRequest().WithCancellation(cancellationToken);
                }
            }
        }
    }
}
