using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class AlbumsPagingModel : PagingModel {
        [JsonProperty("items")] public SimplifiedAlbumModel[] Items { private set; get; }
    }
}
