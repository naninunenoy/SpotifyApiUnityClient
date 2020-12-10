using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class PagingModel {
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("limit")] public int Limit { private set; get; }
        [JsonProperty("next")] public string Next { private set; get; }
        [JsonProperty("offset")] public int Offset { private set; get; }
        [JsonProperty("previous")] public string Previous { private set; get; }
        [JsonProperty("total")] public int Total { private set; get; }
    }
}
