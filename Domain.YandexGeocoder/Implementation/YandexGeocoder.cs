using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using Domain.Geocoder;
using Domain.YandexGeocoder.Dtos;
using Newtonsoft.Json;

namespace Domain.YandexGeocoder.Implementation
{
    public class YandexGeocoder : IGeocoder
    {
        public async Task<GeoPoint?> Geocode(string placeDescription)
        {
            var url = $"https://geocode-maps.yandex.ru/1.x/?format=json&geocode={HttpUtility.UrlEncode(placeDescription)}";

            var client = new HttpClient();
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Yandex Geocoder returns {(int) response.StatusCode} status code");
            }

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ResponseDto>(resultString);

            if (!result.Response.GeoObjectCollection.FeatureMembers.Any())
            {
                return null;
            }

            return result.Response
                         .GeoObjectCollection
                         .FeatureMembers
                         .First()
                         .GeoObject
                         .Point
                         .Position;
        }
    }
}