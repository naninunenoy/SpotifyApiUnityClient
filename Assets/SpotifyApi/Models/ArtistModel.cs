using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class ArtistModel {
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        //[JsonProperty("followers")] public object[] Followers { private set; get; }
        [JsonProperty("genres")] public string[] Genres { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("images")] public ImageModel[] Images { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("popularity")] public int Popularity { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }
    }
}
