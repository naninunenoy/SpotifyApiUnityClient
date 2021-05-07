using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class TrackModel {
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("album")] public SimplifiedAlbumModel Album { private set; get; }
        [JsonProperty("artists")] public SimplifiedArtistModel[] Artists { private set; get; }
        [JsonProperty("available_markets")] public string[] AvailableMarkets { private set; get; }
        [JsonProperty("disc_number")] public int DiscNumber { private set; get; }
        [JsonProperty("duration_ms")] public int DurationMs { private set; get; }
        [JsonProperty("explicit")] public bool Explicit { private set; get; }
        [JsonProperty("external_ids")] public ExternalIdModel ExternalIds { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("is_local")] public bool IsLocal { private set; get; }
        [JsonProperty("is_playable")] public bool IsPlayable { private set; get; }
        //[JsonProperty("linked_from")] public object LinkedFrom { private set; get; }
        //[JsonProperty("restrictions")] public object Restrictions { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("popularity")] public int Popularity { private set; get; }
        [JsonProperty("preview_url")] public string PreviewUrl { private set; get; }
        [JsonProperty("track_number")] public int TrackNumber { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }
    }
}
