﻿using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class ExternalIdModel {
        [JsonProperty("upc")] public string Upc { private set; get; }
        [JsonProperty("isrc")] public string Isrc { private set; get; }
    }
}
