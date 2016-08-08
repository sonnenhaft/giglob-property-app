using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using CQRS;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
using Domain.Exceptions;
using Domain.Geocoder;
using Domain.Geocoder.Exceptions;
using Domain.Repositories;
using ExpressMapper.Extensions;

namespace Domain.Entities.Implementation.PropertyOffer.Commands
{
    public class PropertyOffer_CreateCommand : ICommand
    {
        public PropertyOfferCreateContext CreateContext { get; set; }

        public PropertyOffer_CreateCommand(PropertyOfferCreateContext createContext)
        {
            CreateContext = createContext;
        }
    }

    public class PropertyOffer_CreateCommandHandler : ICommandHandler<PropertyOffer_CreateCommand>
    {
        private readonly IPropertyOfferRepository _propertyOfferRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IGeocoder _geocoder;

        public PropertyOffer_CreateCommandHandler(IPropertyOfferRepository propertyOfferRepository, ICityRepository cityRepository, IGeocoder geocoder)
        {
            _propertyOfferRepository = propertyOfferRepository;
            _cityRepository = cityRepository;
            _geocoder = geocoder;
        }

        public void Handle(PropertyOffer_CreateCommand command)
        {
            var city = _cityRepository.GetAll()
                                      .Include(c => c.Districts)
                                      .FirstOrDefault(c => c.Id == command.CreateContext.CityId);

            if (city == null)
            {
                throw new NotFoundException("City not found");
            }

            var offer = command.CreateContext.Map<PropertyOfferCreateContext, PropertyOffer>();
            var point = AsyncHelpers.RunSync(
                () => _geocoder.Geocode(
                    $"{city.Name}, улица {command.CreateContext.StreetName}, дом {command.CreateContext.HouseNumber}" +
                    $"{(command.CreateContext.Housing != null && command.CreateContext.Housing.Any() ? ", корпус " + command.CreateContext.Housing : "")}"));

            if (!point.HasValue)
            {
                throw new GeoPointNotFoundException();
            }

            offer.Location = DbGeography.FromText($"POINT({point.Value.Lon.ToString(CultureInfo.InvariantCulture)} {point.Value.Lat.ToString(CultureInfo.InvariantCulture)})");

            _propertyOfferRepository.Add(offer);
        }
    }
}