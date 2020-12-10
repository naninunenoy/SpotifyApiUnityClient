using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class PlaylistsPagingModel : PagingModel {
        [JsonProperty("items")] public SimplifiedPlaylistModel[] Items { private set; get; }
    }
}
