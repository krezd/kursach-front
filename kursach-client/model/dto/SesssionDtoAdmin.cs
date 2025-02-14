using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursach_client.model.dto
{
    public class SesssionDtoAdmin
    {
        public Guid Id { get; set; }
        public DateTimeOffset StartSession { get; set; }
        public DateTimeOffset? EndSession { get; set; }
        public UserDto User { get; set; }
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan GOOD { get; set; }
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan BAD { get; set; }
        [JsonConverter(typeof(SecondsToTimeSpanConverter))]
        public TimeSpan NEUTRAL { get; set; }
    }

    public class SecondsToTimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan ReadJson(JsonReader reader, Type objectType, TimeSpan existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Float || reader.TokenType == JsonToken.Integer)
            {
                // Преобразуем секунды в TimeSpan
                double seconds = Convert.ToDouble(reader.Value);
                return TimeSpan.FromSeconds(seconds);
            }
            throw new JsonSerializationException($"Unexpected token type: {reader.TokenType}");
        }

        public override void WriteJson(JsonWriter writer, TimeSpan value, JsonSerializer serializer)
        {
            // Преобразуем TimeSpan обратно в секунды
            writer.WriteValue(value.TotalSeconds);
        }
    }

}
