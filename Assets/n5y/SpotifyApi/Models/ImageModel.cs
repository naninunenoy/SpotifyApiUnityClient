using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class ImageModel {
        [JsonProperty("height")] public float? Height { private set; get; }
        [JsonProperty("url")] public string Url { private set; get; }
        [JsonProperty("width")] public float? Width { private set; get; }
    }
}
