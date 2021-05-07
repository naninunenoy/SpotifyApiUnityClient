using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class ExternalUrlModel {
        [JsonProperty("spotify")] public string Spotify { private set; get; }
    }
}
