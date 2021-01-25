using System;
using UniRx;
using UnityEngine;

namespace SpotifyApi.SpotifyConnect {
    public interface ISpotifyConnectClient : IDisposable {
        IReadOnlyReactiveProperty<string> TrackName { get; }
        IReadOnlyReactiveProperty<string> AlbumName { get; }
        IReadOnlyReactiveProperty<string> ArtistName { get; }
        IReadOnlyReactiveProperty<Sprite> Image { get; }
        IReadOnlyReactiveProperty<float> Progress { get; }
        IReadOnlyReactiveProperty<int> ElapsedMs { get; }
    }
}
