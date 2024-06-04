using Microsoft.Data.SqlClient.Server;
using System;
using System.Globalization;
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
            if (DateTime.TryParseExact(reader.GetString(), _format, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime value))
            {
                return DateTime.ParseExact(reader.GetString(), _format, null);
            }
            else
            {
                return ChangeDateToDateTime(reader.GetString());
            }
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

        public static DateTime ChangeDateToDateTime(string day)
        {
            DateTime date = DateTime.ParseExact(day, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            string formattedDate = date.ToString("MM/dd/yyyy HH:mm:ss");
            return ParseDay(formattedDate);
        }
    }
}
