using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class SimplifiedPlaylistModel {
        [JsonProperty] string id { set; get; }
        [JsonIgnore] public PlaylistId Id { private set; get; }
        [JsonProperty("collaborative")] public bool collaborative { private set; get; }
        [JsonProperty("description")] public string description { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel external_urls { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("images")] public ImageModel[] Images { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("owner")] public UserModel owner { private set; get; }
        [JsonProperty("public")] public bool Public { private set; get; }
        [JsonProperty("snapshot_id")] public string snapshot_id { private set; get; }
        [JsonProperty("tracks")] public TracksModel Tracks { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }

        [OnDeserialized]
        internal void OnDeserializeFinish(StreamingContext context)
        {
            Id = new PlaylistId(id);
        }
    }

    [JsonObject]
    public class TracksModel {
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("total")] public int Total { private set; get; }

    }
}
