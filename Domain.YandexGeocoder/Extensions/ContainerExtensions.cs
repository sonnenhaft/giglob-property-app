using Domain.Geocoder;
using SimpleInjector;

namespace Domain.YandexGeocoder.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterDomainYandexGeocoderDependencies(this Container container)
        {
            container.Register<IGeocoder, Implementation.YandexGeocoder>(Lifestyle.Transient);
        }
    }
}