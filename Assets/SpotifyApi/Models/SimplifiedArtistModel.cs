using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class SimplifiedArtistModel {
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }
    }
}
