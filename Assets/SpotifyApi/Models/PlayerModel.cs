using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class PlayerModel {
        [JsonProperty("timestamp")] public long Timestamp { private set; get; }
        [JsonProperty("device")] public DeviceModel Device { private set; get; }
        [JsonProperty("progress_ms")] public string ProgressMs { private set; get; }
        [JsonProperty("is_playing")] public bool IsPlaying { private set; get; }
        [JsonProperty("currently_playing_type")] public string CurrentlyPlayingType { private set; get; }
        [JsonProperty("actions")] public ActionModel Actions { private set; get; }
        //[JsonProperty("item")] public object Item { private set; get; }
        [JsonProperty("shuffle_state")] public bool ShuffleState { private set; get; }
        [JsonProperty("repeat_state")] public string RepeatState { private set; get; }
        [JsonProperty("context")] public ContextModel Context { private set; get; }
    }
}
