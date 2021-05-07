using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class ExternalIdModel {
        [JsonProperty("upc")] public string Upc { private set; get; }
        [JsonProperty("isrc")] public string Isrc { private set; get; }
        [JsonProperty("ean")] public string Ean { private set; get; }
    }
}
