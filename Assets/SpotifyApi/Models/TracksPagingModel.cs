using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class TracksPagingModel : PagingModel {
        [JsonProperty("items")] public SimplifiedTrackModel[] Items { private set; get; }
    }
}
