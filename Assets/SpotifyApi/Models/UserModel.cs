using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class UserModel {
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("country")] public string Country { private set; get; }
        [JsonProperty("display_name")] public string DisplayName { private set; get; }
        [JsonProperty("email")] public string Email { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        //[JsonProperty("followers")] public object Followers { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("images")] public ImageModel[] Images { private set; get; }
        [JsonProperty("product")] public string Product { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }
    }
}
