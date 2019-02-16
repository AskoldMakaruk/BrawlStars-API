using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace BrawlStarsAPI.Model
{
    public partial class Leaderboards
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("avatarId")]
        public long AvatarId { get; set; }

        [JsonProperty("avatarUrl")]
        public Uri AvatarUrl { get; set; }

        [JsonProperty("position")]
        public long Position { get; set; }

        [JsonProperty("trophies")]
        public long Trophies { get; set; }

        [JsonProperty("clubName")]
        public string ClubName { get; set; }

        [JsonProperty("expLevel")]
        public long ExpLevel { get; set; }
    }

    public partial class Leaderboard
    {
        public static Leaderboard[] FromJson(string json) => JsonConvert.DeserializeObject<Leaderboard[]>(json, BrawlStarsAPI.Model.Converter.Settings);
    }

    internal static class LeaderboardConverter
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
