using Newtonsoft.Json;

namespace BrawlStarsAPI.Model
{
    public partial class SearchClub
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("memberCount")]
        public long MemberCount { get; set; }

        [JsonProperty("trophies")]
        public long Trophies { get; set; }

        [JsonProperty("requiredTrophies")]
        public long RequiredTrophies { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
    public partial class SearchClub
    {
        public static SearchClub[] FromJson(string json) => JsonConvert.DeserializeObject<SearchClub[]>(json);
    }
   
}

