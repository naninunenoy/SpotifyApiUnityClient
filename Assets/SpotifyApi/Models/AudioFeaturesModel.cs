using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class AudioFeaturesModel {
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("duration_ms")] public long DurationMs { private set; get; }
        [JsonProperty("key")] public int Key { private set; get; }
        [JsonProperty("mode")] public int Mode { private set; get; }
        [JsonProperty("time_signature")] public int TimeSignature { private set; get; }
        [JsonProperty("acousticness")] public float Acousticness { private set; get; }
        [JsonProperty("danceability")] public float Danceability { private set; get; }
        [JsonProperty("energy")] public float Energy { private set; get; }
        [JsonProperty("instrumentalness")] public float Instrumentalness { private set; get; }
        [JsonProperty("liveness")] public float Liveness { private set; get; }
        [JsonProperty("loudness")] public float Loudness { private set; get; }
        [JsonProperty("speechiness")] public float Speechiness { private set; get; }
        [JsonProperty("valence")] public float Valence { private set; get; }
        [JsonProperty("tempo")] public float Tempo { private set; get; }
        [JsonProperty("uri")] public string Uri { private set; get; }
        [JsonProperty("track_href")] public string TrackHref { private set; get; }
        [JsonProperty("analysis_url")] public string AnalysisUrl { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
    }
}
