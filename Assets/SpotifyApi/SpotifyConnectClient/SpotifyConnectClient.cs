using System;
using System.Threading;
using Cysharp.Threading.Tasks;
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
            Observable
                .Interval(TimeSpan.FromSeconds(interval))
                .Subscribe(async _ => {
                    var playing = await api.GetCurrentlyPlayingAsync(attachTo.GetCancellationTokenOnDestroy());
                    if (!playing.IsPlaying) {
                        return;
                    }
                    var track = playing.Item;
                    if (track.Id != currentTrackId) {
                        trackName.Value = track.Name;
                        albumName.Value = track.Album.Name;
                        artistName.Value = track.Artists[0].Name;
                        progress.Value = 0.0F;
                        elapsedMs.Value = 0;
                        UniTask.Run(async () => {
                            await UniTask.Yield();
                            var tex = await Util.DownloadTextureAsync(track.Album.Images[0].Url,
                                attachTo.GetCancellationTokenOnDestroy());
                            image.Value = Util.Texture2Sprite(tex);
                        }).Forget();
                        currentTrackId = track.Id;
                        trackLength = track.DurationMs;
                    } else {
                        elapsedMs.Value = playing.ProgressMs;
                        if (trackLength > 0) {
                            progress.Value = playing.ProgressMs / (float)trackLength;
                        }
                    }
                })
                .AddTo(attachTo);
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
