using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace BrawlStarsAPI.Model
{
    public partial class Profile
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("nameColorCode")]
        public string NameColorCode { get; set; }

        [JsonProperty("brawlersUnlocked")]
        public long BrawlersUnlocked { get; set; }

        [JsonProperty("victories")]
        public long Victories { get; set; }

        [JsonProperty("soloShowdownVictories")]
        public long SoloShowdownVictories { get; set; }

        [JsonProperty("duoShowdownVictories")]
        public long DuoShowdownVictories { get; set; }

        [JsonProperty("totalExp")]
        public long TotalExp { get; set; }

        [JsonProperty("expFmt")]
        public string ExpFmt { get; set; }

        [JsonProperty("expLevel")]
        public long ExpLevel { get; set; }

        [JsonProperty("trophies")]
        public long Trophies { get; set; }

        [JsonProperty("highestTrophies")]
        public long HighestTrophies { get; set; }

        [JsonProperty("avatarId")]
        public long AvatarId { get; set; }

        [JsonProperty("avatarUrl")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("bestTimeAsBigBrawler")]
        public string BestTimeAsBigBrawler { get; set; }

        [JsonProperty("bestRoboRumbleTime")]
        public string BestRoboRumbleTime { get; set; }

        [JsonProperty("hasSkins")]
        public bool HasSkins { get; set; }

        [JsonProperty("club")]
        public PlayerClub Club { get; set; }

        [JsonProperty("brawlers")]
        public Brawler[] Brawlers { get; set; }
    }

    public partial class Brawler
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("hasSkin")]
        public bool HasSkin { get; set; }

        [JsonProperty("skin")]
        public string Skin { get; set; }

        [JsonProperty("trophies")]
        public long Trophies { get; set; }

        [JsonProperty("highestTrophies")]
        public long HighestTrophies { get; set; }

        [JsonProperty("power")]
        public long Power { get; set; }

        [JsonProperty("rank")]
        public long Rank { get; set; }
    }

    public partial class PlayerClub
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public string Role { get; set; }

        [JsonProperty("badgeId")]
        public long BadgeId { get; set; }

        [JsonProperty("badgeUrl")]
        public Uri BadgeUrl { get; set; }

        [JsonProperty("members")]
        public long Members { get; set; }

        [JsonProperty("trophies")]
        public long Trophies { get; set; }

        [JsonProperty("requiredTrophies")]
        public long RequiredTrophies { get; set; }

        [JsonProperty("onlineMembers")]
        public long OnlineMembers { get; set; }
    }

    public partial class Profile
    {
        public static Profile FromJson(string json) => JsonConvert.DeserializeObject<Profile>(json, BrawlStarsAPI.Model.PlayerConverter.Settings);
    }

    internal static class PlayerConverter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}