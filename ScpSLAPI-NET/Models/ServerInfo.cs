using Newtonsoft.Json;

namespace ScpSLAPI_NET.Models
{
    public class ServerInfo
    {
        [JsonProperty(PropertyName = "Success")]
        public bool Success { get; set; }

        [JsonProperty(PropertyName = "Error")]
        public string Error { get; set; }

        [JsonProperty(PropertyName = "Servers")]
        public List<Server> Servers { get; set; }

        [JsonProperty(PropertyName = "Cooldown")]
        public uint Cooldown { get; set; }
    }
}
