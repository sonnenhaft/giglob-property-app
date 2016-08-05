using Newtonsoft.Json;

namespace Domain.YandexGeocoder.Dtos
{
    public class ResponseResponseDto
    {
        [JsonProperty("GeoObjectCollection")]
        public GeoObjectCollectionDto GeoObjectCollection { get; set; }
    }
}