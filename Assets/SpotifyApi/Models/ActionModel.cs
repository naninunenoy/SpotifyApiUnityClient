using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class ActionModel {
        [JsonProperty("disallows")] public DisallowsModel Disallows { private set; get; }
    }
    [JsonObject]
    public class DisallowsModel {
        [JsonProperty("interrupting_playback")] public bool InterruptingPlayback { private set; get; }
        [JsonProperty("pausing")] public bool Pausing { private set; get; }
        [JsonProperty("resuming")] public bool Resuming { private set; get; }
        [JsonProperty("seeking")] public bool Seeking { private set; get; }
        [JsonProperty("skipping_next")] public bool SkippingNext { private set; get; }
        [JsonProperty("skipping_prev")] public bool SkippingPrev { private set; get; }
        [JsonProperty("toggling_repeat_context")] public bool TogglingRepeatContext { private set; get; }
        [JsonProperty("toggling_shuffle")] public bool TogglingShuffle { private set; get; }
        [JsonProperty("toggling_repeat_track")] public bool TogglingRepeatTrack { private set; get; }
        [JsonProperty("transferring_playback")] public bool TransferringPlayback { private set; get; }
    }
}
