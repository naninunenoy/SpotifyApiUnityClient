using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace SpotifyApi.Models {
    [JsonObject]
    public class DeviceModel {
        [JsonProperty] string id { set; get; }
        [JsonIgnore] public DeviceId Id { private set; get; }
        [JsonProperty("is_active")] public bool IsActive { private set; get; }
        [JsonProperty("is_private_session")] public bool IsPrivateSession { private set; get; }
        [JsonProperty("is_restricted")] public bool IsRestricted { private set; get; }
        [JsonProperty("name")] public string Name { private set; get; }
        [JsonProperty("type")] public string Type { private set; get; }
        [JsonProperty("volume_percent")] public int? VolumePercent { private set; get; }

        [OnDeserialized]
        internal void OnDeserializeFinish(StreamingContext context) {
            Id = new DeviceId(id);
        }
    }

    [JsonObject]
    public class DeviceListModel {
        [JsonProperty("devices")] public DeviceModel[] Devices { private set; get; }
    }
}
