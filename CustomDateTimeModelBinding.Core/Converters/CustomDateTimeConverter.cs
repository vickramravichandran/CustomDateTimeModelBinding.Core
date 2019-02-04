using CustomDateTimeModelBinding.Core.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace CustomDateTimeModelBinding.Core.Converters
{
    public class CustomDateTimeConverter : DateTimeConverterBase
    {
        private readonly string dateFormat = null;
        private readonly DateTimeConverterBase innerConverter = null;

        public CustomDateTimeConverter()
            : this(dateFormat: null) { }

        public CustomDateTimeConverter(string dateFormat = null)
            : this(dateFormat, innerConverter: new IsoDateTimeConverter()) { }

        public CustomDateTimeConverter(string dateFormat = null, DateTimeConverterBase innerConverter = null)
        {
            this.dateFormat = dateFormat;
            this.innerConverter = innerConverter ?? new IsoDateTimeConverter();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var isNullableType = Helper.IsNullableType(objectType);

            if (reader.TokenType == JsonToken.Null)
            {
                if (isNullableType)
                {
                    return null;
                }

                throw new JsonSerializationException($"Cannot convert null value to {objectType}.");
            }

            if (reader.TokenType != JsonToken.String)
            {
                throw new JsonSerializationException($"Unexpected token parsing date. Expected {nameof(String)}, got {reader.TokenType}.");
            }

            var dateToParse = reader.Value.ToString();

            if (isNullableType && string.IsNullOrWhiteSpace(dateToParse))
            {
                return null;
            }

            if (string.IsNullOrEmpty(this.dateFormat))
            {
                return Helper.ParseDateTime(dateToParse);
            }

            return Helper.ParseDateTime(dateToParse, new string[] { this.dateFormat });
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            this.innerConverter?.WriteJson(writer, value, serializer);
        }
    }
}
