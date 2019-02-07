using Newtonsoft.Json;
using System;

namespace BrawlStars.Model
{
    public partial class Misc
    {
        [JsonProperty("timeUntilSeasonEndInSeconds")]
        public long TimeUntilSeasonEndInSeconds { get; set; }

        [JsonProperty("timeUntilSeasonEnd")]
        public DateTimeOffset TimeUntilSeasonEnd { get; set; }

        [JsonProperty("timeUntilShopResetInSeconds")]
        public long TimeUntilShopResetInSeconds { get; set; }

        [JsonProperty("timeUntilShopReset")]
        public DateTimeOffset TimeUntilShopReset { get; set; }

        [JsonProperty("serverDateYear")]
        public long ServerDateYear { get; set; }

        [JsonProperty("serverDateDayOfYear")]
        public long ServerDateDayOfYear { get; set; }
    }
}
