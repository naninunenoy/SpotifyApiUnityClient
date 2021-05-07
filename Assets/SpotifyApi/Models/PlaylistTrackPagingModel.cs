using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class PlaylistTrackPagingModel : PagingModel {
        [JsonProperty("items")] public PlaylistTrackModel[] Items { private set; get; }
    }

    [JsonObject]
    public class PlaylistTrackModel {
        [JsonProperty("added_at")] public string AddedAt { private set; get; }
        [JsonProperty("added_by")] public UserModel AddedBy { private set; get; }
        [JsonProperty("is_local")] public bool IsLocal { private set; get; }
        [JsonProperty("track")] public TrackModel Track { private set; get; }
    }
}
