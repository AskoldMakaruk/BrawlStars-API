using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace BrawlStarsAPI.Model
{
 
    public partial class Events
    {
        [JsonProperty("current")]
        public Event[] Event { get; set; }

        [JsonProperty("upcoming")]
        public Event[] Upcoming { get; set; }
    }

    public partial class Event
    {
        [JsonProperty("slot")]
        public long Slot { get; set; }

        [JsonProperty("slotName")]
        public string SlotName { get; set; }

        [JsonProperty("startTimeInSeconds")]
        public long? StartTimeInSeconds { get; set; }

        [JsonProperty("startTime")]
        public DateTimeOffset? StartTime { get; set; }

        [JsonProperty("endTimeInSeconds")]
        public long EndTimeInSeconds { get; set; }

        [JsonProperty("endTime")]
        public DateTimeOffset EndTime { get; set; }

        [JsonProperty("freeKeys")]
        public long FreeKeys { get; set; }

        [JsonProperty("mapId")]
        public long MapId { get; set; }

        [JsonProperty("mapName")]
        public string MapName { get; set; }

        [JsonProperty("mapImageUrl")]
        public Uri MapImageUrl { get; set; }

        [JsonProperty("gameMode")]
        public string GameMode { get; set; }

        [JsonProperty("hasModifier")]
        public bool HasModifier { get; set; }

        [JsonProperty("modifierId")]
        public long? ModifierId { get; set; }

        [JsonProperty("modifierName")]
        public string ModifierName { get; set; }
    }

    public partial class Events
    {
        public static Events FromJson(string json) => JsonConvert.DeserializeObject<Events>(json, BrawlStarsAPI.Model.EventsConverter.Settings);
    }

    internal static class EventsConverter
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
