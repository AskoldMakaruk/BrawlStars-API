using Newtonsoft.Json;
using System;

namespace BrawlStars.Model
{
    public partial class Leaderboard
    {
        [JsonProperty("id")]
        public Id Id { get; set; }

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
}
