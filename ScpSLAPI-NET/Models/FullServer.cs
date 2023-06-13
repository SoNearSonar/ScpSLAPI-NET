using System.Text.Json.Serialization;

namespace ScpSLAPI_NET.Models
{
    public class FullServer
    {
        [JsonPropertyName("serverId")]
        public int ServerId { get; set; }

        [JsonPropertyName("accountId")]
        public int AccountId { get; set; }

        [JsonPropertyName("ip")]
        public string IP { get; set; }

        [JsonPropertyName("port")]
        public int Port { get; set; }

        [JsonPropertyName("players")]
        public string Players { get; set; }

        [JsonPropertyName("distance")]
        public int Distance { get; set; }

        [JsonPropertyName("info")]
        public string Info { get; set; }

        [JsonPropertyName("pastebin")]
        public string Pastebin { get; set; }

        [JsonPropertyName("version")]
        public string Version { get; set; }

        [JsonPropertyName("privateBeta")]
        public bool IsPrivateBeta { get; set; }

        [JsonPropertyName("modded")]
        public bool IsModded { get; set; }

        [JsonPropertyName("modFlags")]
        public int ModFlags { get; set; }

        [JsonPropertyName("whitelist")]
        public bool HasWhitelist { get; set; }

        [JsonPropertyName("isoCode")]
        public string ISOCode { get; set; }

        [JsonPropertyName("continentCode")]
        public string ContinentCode { get; set; }

        [JsonPropertyName("latitude")]
        public float Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public float Longitude { get; set; }

        [JsonPropertyName("official")]
        public string OfficialTitle { get; set; }

        [JsonPropertyName("officialCode")]
        public int OfficialCode { get; set; }

        [JsonPropertyName("displaySection")]
        public int DisplaySection { get; set; }
    }
}
