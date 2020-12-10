using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class UsersSavedAlbumsModel : PagingModel {
        [JsonProperty("items")] public SavedAlbumModel[] Items { private set; get; }
    }

    [JsonObject]
    public class SavedAlbumModel {
        [JsonProperty("added_at")] public string AddedAt { private set; get; }
        [JsonProperty("album")] public AlbumModel Album { private set; get; }
    }
}
