using Newtonsoft.Json;

namespace n5y.SpotifyApi.Models {
    [JsonObject]
    public class AlbumModel {
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("album_type")] public string AlbumType { private set; get; }
        [JsonProperty("artists")] public SimplifiedArtistModel[] Artists { private set; get; }
        [JsonProperty("available_markets")] public string[] AvailableMarkets { private set; get; }
        [JsonProperty("copyrights")] public CopyrightsModel[] Copyrights { private set; get; }
        [JsonProperty("external_ids")] public ExternalIdModel ExternalIds { private set; get; }
        [JsonProperty("external_urls")] public ExternalUrlModel ExternalUrls { private set; get; }
        [JsonProperty("genres")] public string[] Genres { private set; get; }
        [JsonProperty("href")] public string Href { private set; get; }
        [JsonProperty("images")] public ImageModel[] Images { private set; get; }
        [JsonProperty("label")] public string Label { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("popularity")] public int Popularity { private set; get; }
        [JsonProperty("release_date")] public string ReleaseDate { private set; get; }
        [JsonProperty("release_date_precision")] public string ReleaseDatePrecision { private set; get; }
        [JsonProperty("total_tracks")] public int TotalTracks { private set; get; }
        [JsonProperty("tracks")] public TracksPagingModel Tracks { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }
    }
}
