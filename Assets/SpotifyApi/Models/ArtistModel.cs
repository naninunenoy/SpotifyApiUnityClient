using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class ArtistModel {
        [JsonProperty] string id;
        [JsonIgnore] public ArtistId Id { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }

        [OnDeserialized]
        internal void OnDeserializeFinish(StreamingContext context)
        {
            Id = new ArtistId(id);
        }
    }
}
