using System;
using UnityEngine;

namespace SpotifyApi.Models {
    [Serializable]
    public class ExternalUrlModel {
        public string Spotify => spotify;

        [SerializeField] string spotify;
    }
}
