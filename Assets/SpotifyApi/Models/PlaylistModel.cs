using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class PlaylistModel {
        [JsonProperty] string id { set; get; }
        [JsonIgnore] public PlaylistId Id { private set; get; }
        [JsonProperty("collaborative")] public bool Collaborative { private set; get; }
        [JsonProperty("description")] public string Description { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        //[JsonProperty("followers")] public object Followers { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("images")] public ImageModel[] Images { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("owner")] public UserModel Owner { private set; get; }
        [JsonProperty("public")] public bool? Public { private set; get; }
        [JsonProperty("snapshot_id")] public string SnapshotId { private set; get; }
        [JsonProperty("tracks")] public PlaylistTrackPagingModel Tracks { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }

        [OnDeserialized]
        internal void OnDeserializeFinish(StreamingContext context)
        {
            Id = new PlaylistId(id);
        }
    }
}
