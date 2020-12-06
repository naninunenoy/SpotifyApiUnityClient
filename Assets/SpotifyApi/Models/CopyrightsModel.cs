using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class CopyrightsModel {
        [JsonProperty("text")] public string Text { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
    }
}
