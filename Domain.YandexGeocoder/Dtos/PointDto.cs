using Domain.Geocoder;
using Domain.YandexGeocoder.JsonConverters;
using Newtonsoft.Json;

namespace Domain.YandexGeocoder.Dtos
{
    public class PointDto
    {
        [JsonProperty("pos")]
        [JsonConverter(typeof (GeoPointJsonConverter))]
        public GeoPoint Position { get; set; }
    }
}