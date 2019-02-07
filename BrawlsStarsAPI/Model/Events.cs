using Newtonsoft.Json;
using System;

namespace BrawlStars.Model
{
    public partial class Events
    {
        [JsonProperty("current")]
        public Event[] Current { get; set; }

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
        public object ModifierId { get; set; }

        [JsonProperty("modifierName")]
        public object ModifierName { get; set; }
    }
}
