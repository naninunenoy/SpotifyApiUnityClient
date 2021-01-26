using UnityEngine;

namespace SpotifyApi.SpotifyConnect.View {
    public interface ISpotifyConnectClientView {
        void SetTrack(string track, string artist);
        void SetImage(Sprite image);
        void UpdateTime(int elapsed, float progress);
    }
}
