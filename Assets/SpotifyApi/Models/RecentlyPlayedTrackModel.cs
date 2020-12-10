using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class RecentlyPlayedTrackModel {
        [JsonProperty("items")] public RecentlyPlayedTrackItem Items { private set; get; }
        [JsonProperty("next")] public string Next { private set; get; }
        [JsonProperty("cursors")] public CursorsModel Cursors { private set; get; }
        [JsonProperty("limit")] public string Limit { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
    }
    [JsonObject]
    public class RecentlyPlayedTrackItem {
        [JsonProperty("track")] public SimplifiedTrackModel SimplifiedTrack { private set; get; }
        [JsonProperty("played_at")] public string PlayedAt { private set; get; }
        [JsonProperty("context")] public ContextModel Context { private set; get; }
    }
}
