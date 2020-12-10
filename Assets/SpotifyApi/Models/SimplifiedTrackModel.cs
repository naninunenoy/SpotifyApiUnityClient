using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class SimplifiedTrackModel {
        [JsonProperty] string id { set; get; }
        [JsonIgnore] public TrackId Id { private set; get; }
        [JsonProperty("artists")] public ArtistModel[] Artists { private set; get; }
        [JsonProperty("available_markets")] public string[] AvailableMarkets { private set; get; }
        [JsonProperty("disc_number")] public int DiscNumber { private set; get; }
        [JsonProperty("duration_ms")] public int DurationMs { private set; get; }
        [JsonProperty("explicit")] public bool Explicit { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("is_local")] public bool IsLocal { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("preview_url")] public string PreviewUrl { private set; get; }
        [JsonProperty("track_number")] public int TrackNumber { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }

        [OnDeserialized]
        internal void OnDeserializeFinish(StreamingContext context)
        {
            Id = new TrackId(id);
        }
    }
}
