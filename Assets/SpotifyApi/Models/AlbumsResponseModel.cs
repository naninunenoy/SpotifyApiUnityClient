using System;
using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class AlbumsResponseModel {
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("items")] public AlbumItem[] Items { private set; get; }
    }

    [JsonObject]
    public class AlbumItem {
        [JsonProperty("added_at")] public string AddedAt { private set; get; }
        [JsonProperty("album")] public AlbumModel Album { private set; get; }
    }
}
