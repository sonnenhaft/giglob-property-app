using Newtonsoft.Json;

namespace Domain.YandexGeocoder.Dtos
{
    public class FeatureMemberDto
    {
        [JsonProperty("GeoObject")]
        public GeoObjectDto GeoObject { get; set; }
    }
}