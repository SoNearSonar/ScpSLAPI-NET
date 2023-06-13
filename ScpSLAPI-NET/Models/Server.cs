using System.Text.Json.Serialization;

namespace ScpSLAPI_NET.Models
{
    public class Server
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }

        [JsonPropertyName("Port")]
        public int Port { get; set; }

        [JsonPropertyName("Online")]
        public bool Online { get; set; }

        [JsonPropertyName("LastOnline")]
        public string LastOnline { get; set; }

        [JsonPropertyName("Players")]
        public string Players { get; set; }

        [JsonPropertyName("PlayersList")]
        public List<string> PlayersList { get; set; }

        [JsonPropertyName("Info")]
        public string Info { get; set; }

        [JsonPropertyName("Version")]
        public string Version { get; set; }

        [JsonPropertyName("Pastebin")]
        public string Pastebin { get; set; }

        [JsonPropertyName("FF")]
        public bool HasFriendlyFire { get; set; }

        [JsonPropertyName("WL")]
        public bool Whitelist { get; set; }

        [JsonPropertyName("Modded")]
        public string IsModded { get; set; }

        [JsonPropertyName("Mods")]
        public int ModsCount { get; set; }

        [JsonPropertyName("Suppress")]
        public bool IsHiddenFromList { get; set; }

        [JsonPropertyName("AutoSuppress")]
        public bool IsHiddenAutomatically { get; set; }
    }
}
