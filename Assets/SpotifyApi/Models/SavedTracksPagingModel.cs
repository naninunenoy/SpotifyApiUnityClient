using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class SavedTracksPagingModel : PagingModel {
        [JsonProperty("items")] public SavedTrackModel[] Items { private set; get; }
    }

    [JsonObject]
    public class SavedTrackModel {
        [JsonProperty("added_at")] public string AddedAt { private set; get; }
        [JsonProperty("track")] public TrackModel Track { private set; get; }
    }
}
