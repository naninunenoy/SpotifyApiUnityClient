using System;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using SpotifyApi.Models;
using UniRx;
using UnityEngine;

namespace SpotifyApi.SpotifyConnect {
    public class SpotifyConnectClient : ISpotifyConnectClient {
        ISpotifyConnectApiAdapter api;
        ReactiveProperty<string> trackName;
        ReactiveProperty<string> albumName;
        ReactiveProperty<string> artistName;
        ReactiveProperty<Sprite> image;
        ReactiveProperty<float> progress;
        ReactiveProperty<int> elapsedMs;


        public SpotifyConnectClient(ISpotifyConnectApiAdapter api, float interval, Component attachTo) {
            this.api = api;
            trackName = new ReactiveProperty<string>();
            albumName = new ReactiveProperty<string>();
            artistName = new ReactiveProperty<string>();
            image = new ReactiveProperty<Sprite>();
            progress = new ReactiveProperty<float>();
            elapsedMs = new ReactiveProperty<int>();

            // Spotifyの再生情報を定期的に取りに行く
            var currentTrackId = TrackId.Empty;
            var trackLength = 0;
            var ct = attachTo.GetCancellationTokenOnDestroy();
            UniTaskAsyncEnumerable
                .Interval(TimeSpan.FromSeconds(interval))
                .SelectAwait(_ => api.GetCurrentlyPlayingAsync(ct))
                .Where(x => x.IsPlaying)
                .ForEachAsync(x => {
                    var track = x.Item;
                    if (track.Id != currentTrackId) {
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
                        currentTrackId = track.Id;
                        trackLength = track.DurationMs;
                    } else {
                        elapsedMs.Value = x.ProgressMs;
                        if (trackLength > 0) {
                            progress.Value = x.ProgressMs / (float)trackLength;
                        }
                    }
                }, ct);
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
