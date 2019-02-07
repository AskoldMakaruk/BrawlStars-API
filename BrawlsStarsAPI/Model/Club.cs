using BrawlStars.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
namespace BrawlsStarsAPI.Model
{
    public partial class Club
    {
        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }

        [JsonProperty("badgeId")]
        public long BadgeId { get; set; }

        [JsonProperty("badgeUrl")]
        public Uri BadgeUrl { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("membersCount")]
        public long MembersCount { get; set; }

        [JsonProperty("onlineMembers")]
        public long OnlineMembers { get; set; }

        [JsonProperty("trophies")]
        public long Trophies { get; set; }

        [JsonProperty("requiredTrophies")]
        public long RequiredTrophies { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("members")]
        public Member[] Members { get; set; }
    }

    public partial class Member
    {
        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("role")]
        public Role Role { get; set; }

        [JsonProperty("expLevel")]
        public long ExpLevel { get; set; }

        [JsonProperty("trophies")]
        public long Trophies { get; set; }

        [JsonProperty("avatarId")]
        public long AvatarId { get; set; }

        [JsonProperty("avatarUrl")]
        public Uri AvatarUrl { get; set; }
    }

    public enum Role { Member, President, Senior, VicePresident };

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                RoleConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class RoleConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Role) || t == typeof(Role?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "Member":
                    return Role.Member;
                case "President":
                    return Role.President;
                case "Senior":
                    return Role.Senior;
                case "Vice President":
                    return Role.VicePresident;
            }
            throw new Exception("Cannot unmarshal type Role");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Role)untypedValue;
            switch (value)
            {
                case Role.Member:
                    serializer.Serialize(writer, "Member");
                    return;
                case Role.President:
                    serializer.Serialize(writer, "President");
                    return;
                case Role.Senior:
                    serializer.Serialize(writer, "Senior");
                    return;
                case Role.VicePresident:
                    serializer.Serialize(writer, "Vice President");
                    return;
            }
            throw new Exception("Cannot marshal type Role");
        }

        public static readonly RoleConverter Singleton = new RoleConverter();
    }
}
