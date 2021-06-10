using UnityEngine;

namespace n5y.SpotifyApi.Ui.Core {
    public readonly struct MusicTimeTuple {
        public readonly float elapsedSeconds;
        public readonly float totalSeconds;

        public MusicTimeTuple(float elapsedSeconds, float totalSeconds) {
            this.elapsedSeconds = elapsedSeconds;
            this.totalSeconds = totalSeconds;
        }

        public static MusicTimeTuple FromRatio(float ratio, float total) {
            return new MusicTimeTuple(total * Mathf.Clamp01(ratio), total);
        }
    }
}
