using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class ExternalUrlModel {
        [JsonProperty("spotify")] public string Spotify { private set; get; }
    }
}
