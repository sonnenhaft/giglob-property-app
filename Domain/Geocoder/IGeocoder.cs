using System.Threading.Tasks;

namespace Domain.Geocoder
{
    public interface IGeocoder
    {
        Task<GeoPoint?> Geocode(string placeDescription);
    }
}