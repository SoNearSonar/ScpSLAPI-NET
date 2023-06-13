using System.Text.Json.Serialization;

namespace ScpSLAPI_NET.Models
{
    public class ServerInfo
    {
        [JsonPropertyName("Success")]
        public bool Success { get; set; }

        [JsonPropertyName("Error")]
        public string Error { get; set; }

        [JsonPropertyName("Servers")]
        public List<Server> Servers { get; set; }

        [JsonPropertyName("Cooldown")]
        public uint Cooldown { get; set; }
    }
}
