using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class CursorsModel {
        [JsonProperty("after")] public string After { private set; get; }
        [JsonProperty("before")] public string Before { private set; get; }
    }
}
