using Newtonsoft.Json;

namespace ScpSLAPI_NET.Models
{
    public class Server
    {
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Port")]
        public int Port { get; set; }

        [JsonProperty(PropertyName = "LastOnline")]
        public string LastOnline { get; set; }

        [JsonProperty(PropertyName = "Players")]
        public string Players { get; set; }

        [JsonProperty(PropertyName = "PlayersList")]
        public List<string> PlayersList { get; set; }

        [JsonProperty(PropertyName = "Info")]
        public string Info { get; set; }

        [JsonProperty(PropertyName = "FF")]
        public bool HasFriendlyFire { get; set; }

        [JsonProperty(PropertyName = "WL")]
        public bool Whitelist { get; set; }

        [JsonProperty(PropertyName = "Modded")]
        public string IsModded { get; set; }

        [JsonProperty(PropertyName = "Mods")]
        public int ModsCount { get; set; }

        [JsonProperty(PropertyName = "Suppress")]
        public bool IsHiddenFromList { get; set; }

        [JsonProperty(PropertyName = "AutoSuppress")]
        public bool IsHiddenAutomatically { get; set; }
    }
}
