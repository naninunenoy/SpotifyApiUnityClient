using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class PlaylistsPagingModel : PagingModel {
        [JsonProperty("items")] public SimplifiedPlaylistModel[] Items { private set; get; }
    }
}
