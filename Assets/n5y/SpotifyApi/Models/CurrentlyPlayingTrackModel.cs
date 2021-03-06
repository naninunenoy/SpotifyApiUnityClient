using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class CurrentlyPlayingTrackModel {
        [JsonProperty("context")] public ContextModel Context { private set; get; }
        [JsonProperty("timestamp")] public long Timestamp { private set; get; }
        [JsonProperty("progress_ms")] public int ProgressMs { private set; get; }
        [JsonProperty("is_playing")] public bool IsPlaying { private set; get; }
        [JsonProperty("currently_playing_type")] public string CurrentlyPlayingType { private set; get; }
        [JsonProperty("actions")] public ActionModel Actions { private set; get; }
        [JsonProperty("item")] public TrackModel Item { private set; get; }
    }
}
