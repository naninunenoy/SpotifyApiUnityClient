using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class AlbumsPagingModel : PagingModel {
        [JsonProperty("items")] public SimplifiedAlbumModel[] Items { private set; get; }
    }
}
