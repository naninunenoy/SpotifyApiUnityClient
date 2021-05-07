using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class TracksPagingModel : PagingModel {
        [JsonProperty("items")] public SimplifiedTrackModel[] Items { private set; get; }
    }
}
