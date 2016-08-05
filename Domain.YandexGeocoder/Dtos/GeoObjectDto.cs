using Newtonsoft.Json;

namespace Domain.YandexGeocoder.Dtos
{
    public class GeoObjectDto
    {
        [JsonProperty("Point")]
        public PointDto Point { get; set; }
    }
}