using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class CopyrightsModel {
        [JsonProperty("text")] public string Text { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
    }
}
