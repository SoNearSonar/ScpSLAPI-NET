using Newtonsoft.Json;

namespace ScpSLAPI_NET.Models
{
    public class FullServer
    {
        [JsonProperty(PropertyName = "serverId")]
        public int ServerId { get; set; }

        [JsonProperty(PropertyName = "accountId")]
        public string AccountId { get; set; }

        [JsonProperty(PropertyName = "ip")]
        public string IP { get; set; }

        [JsonProperty(PropertyName = "port")]
        public int Port { get; set; }

        [JsonProperty(PropertyName = "players")]
        public string Players { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public int Distance { get; set; }

        [JsonProperty(PropertyName = "info")]
        public string Info { get; set; }

        [JsonProperty(PropertyName = "pastebin")]
        public string Pastebin { get; set; }

        [JsonProperty(PropertyName = "version")]
        public string Version { get; set; }

        [JsonProperty(PropertyName = "privateBeta")]
        public bool IsPrivateBeta { get; set; }

        [JsonProperty(PropertyName = "modded")]
        public bool IsModded { get; set; }

        [JsonProperty(PropertyName = "modFlags")]
        public int ModFlags { get; set; }

        [JsonProperty(PropertyName = "whitelist")]
        public bool HasWhitelist { get; set; }

        [JsonProperty(PropertyName = "isoCode")]
        public string ISOCode { get; set; }

        [JsonProperty(PropertyName = "continentCode")]
        public string ContinentCode { get; set; }

        [JsonProperty(PropertyName = "latitude")]
        public float Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public float Longitude { get; set; }

        [JsonProperty(PropertyName = "official")]
        public string OfficialTitle { get; set; }

        [JsonProperty(PropertyName = "officialCode")]
        public int OfficialCode { get; set; }

        [JsonProperty(PropertyName = "displaySection")]
        public int DisplaySection { get; set; }
    }
}
