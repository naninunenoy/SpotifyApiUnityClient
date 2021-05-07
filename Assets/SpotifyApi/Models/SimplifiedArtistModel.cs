using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class SimplifiedArtistModel {
        [JsonProperty] string id { set; get; }
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }
    }
}
