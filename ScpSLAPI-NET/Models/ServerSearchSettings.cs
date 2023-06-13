namespace ScpSLAPI_NET.Models
{
    public class ServerSearchSettings
    {
        public uint ID { get; set; }
        public bool? AddLastOnline { get; set; }
        public bool? AddPlayers { get; set; }
        public bool? AddPlayersList { get; set; }
        public bool? AddInfo { get; set; }
        public bool? AddPastebin { get; set; }
        public bool? AddVersion { get; set; }
        public bool? AddFlags { get; set; }
        public bool? AddNicknames { get; set; }
        public bool? AddIsOnline { get; set; }
    }
}
