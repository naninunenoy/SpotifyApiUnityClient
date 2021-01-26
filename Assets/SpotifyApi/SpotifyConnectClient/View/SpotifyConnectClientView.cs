using System;
using UnityEngine;
using UnityEngine.UI;

namespace SpotifyApi.SpotifyConnect.View {
    public class SpotifyConnectClientView : MonoBehaviour, ISpotifyConnectClientView {
        [SerializeField] Text trackText = default;
        [SerializeField] Text artistText = default;
        [SerializeField] Image albumImage = default;
        [SerializeField] Text durationText = default;
        [SerializeField] Slider durationSlider = default;

        void ISpotifyConnectClientView.SetTrack(string track, string artist) {
            trackText.text = track;
            artistText.text = artist;
        }

        void ISpotifyConnectClientView.SetImage(Sprite image) {
            albumImage.sprite = image;
        }

        void ISpotifyConnectClientView.UpdateTime(int elapsed, float progress) {
            var ts = TimeSpan.FromMilliseconds(elapsed);
            durationText.text = ts.ToString(@"m\:ss");
            durationSlider.value = progress;
        }
    }
}
