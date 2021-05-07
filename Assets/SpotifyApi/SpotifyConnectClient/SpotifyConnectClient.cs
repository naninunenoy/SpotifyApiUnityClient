using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using n5y.SpotifyApi.Models;
using UniRx;
using UnityEngine;

namespace n5y.SpotifyApi.SpotifyConnect {
    public class SpotifyConnectClient : ISpotifyConnectClient {
        const int elapsedInterval = 500;
        readonly ReactiveProperty<string> trackName;
        readonly ReactiveProperty<string> albumName;
        readonly ReactiveProperty<string> artistName;
        readonly ReactiveProperty<Sprite> image;
        readonly ReactiveProperty<float> progress;
        readonly ReactiveProperty<int> elapsedMs;

        int trackLength = 0;

        public SpotifyConnectClient(ISpotifyConnectApiAdapter api, float interval, Component attachTo) {
            trackName = new ReactiveProperty<string>();
            albumName = new ReactiveProperty<string>();
            artistName = new ReactiveProperty<string>();
            image = new ReactiveProperty<Sprite>();
            progress = new ReactiveProperty<float>();
            elapsedMs = new ReactiveProperty<int>();

            // Spotifyの再生情報を定期的に取りに行く
            var ct = attachTo.GetCancellationTokenOnDestroy();
            var localElapsed = 0;
            UniTaskAsyncEnumerable
                .Interval(TimeSpan.FromSeconds(interval))
                .SelectAwait(_ => api.GetCurrentlyPlayingAsync(ct))
                .Where(x => x.IsPlaying)
                .Where(x => x.Item != null)
                .ForEachAwaitAsync(async x => {
                    var track = x.Item;
                    await UniTask.Yield();
                    if (!string.IsNullOrEmpty(track.Id)) {
                        trackName.Value = track.Name;
                        albumName.Value = track.Album.Name;
                        artistName.Value = track.Artists[0].Name;
                        progress.Value = 0.0F;
                        elapsedMs.Value = 0;
                        UniTask.Run(async () => {
                            await UniTask.Yield();
                            var tex = await Util.DownloadTextureAsync(track.Album.Images[0].Url, ct);
                            image.Value = Util.Texture2Sprite(tex);
                        }).Forget();
                        trackLength = track.DurationMs;
                    } else {
                        localElapsed = x.ProgressMs;
                        SetElapsed(x.ProgressMs);
                    }
                }, ct);
            // 更新間隔に寄らず、0.5秒周期で経過時間だけ更新
            UniTaskAsyncEnumerable
                .Interval(TimeSpan.FromMilliseconds(elapsedInterval))
                .ForEachAwaitAsync(async _ => {
                    localElapsed += elapsedInterval;
                    await UniTask.Yield();
                    SetElapsed(localElapsed);
                }, ct);
        }

        void SetElapsed(int elapsed) {
            elapsedMs.Value = elapsed;
            if (trackLength > 0) {
                progress.Value = elapsed / (float)trackLength;
            }
        }

        public void Dispose() {
            trackName?.Dispose();
            albumName?.Dispose();
            artistName?.Dispose();
            image?.Dispose();
            progress?.Dispose();
            elapsedMs?.Dispose();
        }

        IReadOnlyReactiveProperty<string> ISpotifyConnectClient.TrackName => trackName;
        IReadOnlyReactiveProperty<string> ISpotifyConnectClient.AlbumName => albumName;
        IReadOnlyReactiveProperty<string> ISpotifyConnectClient.ArtistName => artistName;
        IReadOnlyReactiveProperty<Sprite> ISpotifyConnectClient.Image => image;
        IReadOnlyReactiveProperty<float> ISpotifyConnectClient.Progress => progress;
        IReadOnlyReactiveProperty<int> ISpotifyConnectClient.ElapsedMs => elapsedMs;
    }
}
