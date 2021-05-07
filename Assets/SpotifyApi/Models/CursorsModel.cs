using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class CursorsModel {
        [JsonProperty("after")] public string After { private set; get; }
        [JsonProperty("before")] public string Before { private set; get; }
    }
}
