using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace BrawlStarsAPI.Model
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

    public partial class Misc
    {
        public static Misc FromJson(string json) => JsonConvert.DeserializeObject<Misc>(json, BrawlStarsAPI.Model.Converter.Settings);
    }

    internal static class Converter
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
