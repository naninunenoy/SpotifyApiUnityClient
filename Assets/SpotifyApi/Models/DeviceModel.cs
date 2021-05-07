using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class DeviceModel {
        [JsonProperty("id")] public string Id { private set; get; }
        [JsonProperty("is_active")] public bool IsActive { private set; get; }
        [JsonProperty("is_private_session")] public bool IsPrivateSession { private set; get; }
        [JsonProperty("is_restricted")] public bool IsRestricted { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("volume_percent")] public int? VolumePercent { private set; get; }
    }

    [JsonObject]
    public class DeviceListModel {
        [JsonProperty("devices")] public DeviceModel[] Devices { private set; get; }
    }
}
