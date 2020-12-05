using System;
using UnityEngine;

namespace SpotifyApi.Models {
    [Serializable]
    public class ImageModel {
        [SerializeField] float height;
        [SerializeField] string url;
        [SerializeField] float width;

        public float Height => height;
        public string URL => url;
        public float Width => width;
    }
}
