using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class TracksResponseModel {
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("items")] public SimplifiedTrackModel[] Items { private set; get; }
    }
}
