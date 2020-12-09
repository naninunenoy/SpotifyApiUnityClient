using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class CurrentlyPlayingTrackModel {
        [JsonProperty("context")] public ContextModel Context { private set; get; }
        [JsonProperty("timestamp")] public long Timestamp { private set; get; }
        [JsonProperty("progress_ms")] public string ProgressMs { private set; get; }
        [JsonProperty("is_playing")] public bool IsPlaying { private set; get; }
        [JsonProperty("currently_playing_type")] public string CurrentlyPlayingType { private set; get; }
        [JsonProperty("actions")] public ActionModel Actions { private set; get; }
        [JsonProperty("item")] public CurrentlyPlayingItem Item { private set; get; }
    }

    [JsonObject]
    public class CurrentlyPlayingItem {
        [JsonProperty("album")] public AlbumModel Album { private set; get; }
        [JsonProperty("artists")] public ArtistModel[] Artists { private set; get; }
        [JsonProperty("available_markets")] public string[] AvailableMarkets { private set; get; }
        [JsonProperty("disc_number")] public int DiscNumber { private set; get; }
        [JsonProperty("duration_ms")] public long DurationMs { private set; get; }
        [JsonProperty("explicit")] public bool Explicit { private set; get; }
        [JsonProperty("external_ids")] public ExternalIdModel ExternalIds { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("popularity")] public int Popularity { private set; get; }
        [JsonProperty("preview_url")] public int PreviewUrl { private set; get; }
        [JsonProperty("track_number")] public int TrackNumber { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }
    }
}
