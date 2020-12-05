using System;
using UnityEngine;

namespace SpotifyApi.Models {
    [Serializable]
    public class UserModel {
        [SerializeField] string display_name;
        [SerializeField] string email;
        [SerializeField] ExternalUrlModel external_urls;
        [SerializeField] string href;
        [SerializeField] string id;
        [SerializeField] ImageModel[] images;
        [SerializeField] string product;
        [SerializeField] string type;
        [SerializeField] string uri;

        public string Uri => uri;
        public string Type => type;
        public string Product => product;
        public ImageModel[] Images => images;
        public string ID => id;
        public string Href => href;
        public ExternalUrlModel ExternalUrls => external_urls;
        public string Email => email;
        public string DisplayName => display_name;
    }
}
