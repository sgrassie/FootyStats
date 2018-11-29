namespace FootyStats
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class FootballData
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("filters")]
        public Filters Filters { get; set; }

        [JsonProperty("competitions")]
        public Competition[] Competitions { get; set; }
    }

    public partial class Competition
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("area")]
        public Area Area { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("emblemUrl")]
        public Uri EmblemUrl { get; set; }

        [JsonProperty("plan")]
        public Plan Plan { get; set; }

        [JsonProperty("currentSeason")]
        public CurrentSeason CurrentSeason { get; set; }

        [JsonProperty("numberOfAvailableSeasons")]
        public long NumberOfAvailableSeasons { get; set; }

        [JsonProperty("lastUpdated")]
        public DateTimeOffset LastUpdated { get; set; }
    }

    public partial class Area
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public partial class CurrentSeason
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("startDate")]
        public DateTimeOffset StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTimeOffset EndDate { get; set; }

        [JsonProperty("currentMatchday")]
        public long? CurrentMatchday { get; set; }

        [JsonProperty("winner")]
        public Winner Winner { get; set; }

        public override string ToString()
        {
            return $"{StartDate.ToString()}";
        }
    }

    public partial class Winner
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("shortName")]
        public string ShortName { get; set; }

        [JsonProperty("tla")]
        public string Tla { get; set; }

        [JsonProperty("crestUrl")]
        public Uri CrestUrl { get; set; }
    }

    public partial class Filters
    {
    }

    public enum Plan { TierFour, TierOne, TierThree, TierTwo };

    public partial class FootballData
    {
        public static FootballData FromJson(string json) => JsonConvert.DeserializeObject<FootballData>(json, FootyStats.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this FootballData self) => JsonConvert.SerializeObject(self, FootyStats.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                PlanConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class PlanConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Plan) || t == typeof(Plan?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "TIER_FOUR":
                    return Plan.TierFour;
                case "TIER_ONE":
                    return Plan.TierOne;
                case "TIER_THREE":
                    return Plan.TierThree;
                case "TIER_TWO":
                    return Plan.TierTwo;
            }
            throw new Exception("Cannot unmarshal type Plan");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (Plan)untypedValue;
            switch (value)
            {
                case Plan.TierFour:
                    serializer.Serialize(writer, "TIER_FOUR");
                    return;
                case Plan.TierOne:
                    serializer.Serialize(writer, "TIER_ONE");
                    return;
                case Plan.TierThree:
                    serializer.Serialize(writer, "TIER_THREE");
                    return;
                case Plan.TierTwo:
                    serializer.Serialize(writer, "TIER_TWO");
                    return;
            }
            throw new Exception("Cannot marshal type Plan");
        }

        public static readonly PlanConverter Singleton = new PlanConverter();
    }
}