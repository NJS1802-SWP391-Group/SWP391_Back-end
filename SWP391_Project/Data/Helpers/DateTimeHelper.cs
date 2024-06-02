using Microsoft.Data.SqlClient.Server;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SWP391_Project.Helpers
{
    public class DateTimeHelper : JsonConverter<DateTime>
    {
        private readonly string _format;

        public DateTimeHelper(string format)
        {
            _format = format;
        }

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), _format, null);
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_format));
        }
        public static DateTime ParseDay(string value)
        {
            var format = "MM/dd/yyyy HH:mm:ss";
            return DateTime.ParseExact(value, format, null);
        }
    }
}
