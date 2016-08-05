using System;
using Domain.Geocoder;
using Newtonsoft.Json;

namespace Domain.YandexGeocoder.JsonConverters
{
    public class GeoPointJsonConverter : JsonConverter
    {
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (GeoPoint);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var lonlat = serializer.Deserialize<string>(reader);

            return new GeoPoint(lonlat);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}