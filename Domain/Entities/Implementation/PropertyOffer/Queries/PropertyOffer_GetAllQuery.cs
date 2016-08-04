using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Spatial;
using System.Globalization;
using System.Linq;
using CQRS;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
using Domain.Repositories;

namespace Domain.Entities.Implementation.PropertyOffer.Queries
{
    public class PropertyOffer_GetAllQuery : IQuery
    {
        /// <summary>
        ///     Кол-во записей для получения
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        ///     Кол-во эл-в для пропуска
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        ///     Стоимость От
        /// </summary>
        public decimal? MinCost { get; set; }

        /// <summary>
        ///     Стоимость До
        /// </summary>
        public decimal? MaxCost { get; set; }

        /// <summary>
        ///     Кол-во комнат
        /// </summary>
        public int? RoomCount { get; set; }

        /// <summary>
        ///     Ид метро
        /// </summary>
        public IEnumerable<long> MetroIds { get; set; }

        /// <summary>
        ///     Видимая область на карте
        /// </summary>
        public ViewPortDto ViewPort { get; set; }
    }

    public class PropertyOffer_GetAllQueryHandler : IQueryHandler<PropertyOffer_GetAllQuery, IEnumerable<PropertyOffer>>
    {
        private readonly IPropertyOfferRepository _offerRepository;
        private static readonly int CoordinateSystemId = 4326;

        public PropertyOffer_GetAllQueryHandler(IPropertyOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IEnumerable<PropertyOffer> Handle(PropertyOffer_GetAllQuery reqQuery)
        {
            var query = _offerRepository.GetAll()
                                        .Include(offer => offer.LocalPropertyOfferData)
                                        .Include(offer => offer.LocalPropertyOfferData.Photoes)
                                        .Include(offer => offer.LocalPropertyOfferData.NearMetroStations)
                                        .Include(offer => offer.LocalPropertyOfferData.NearMetroStations.Select(station => station.MetroBranchStation))
                                        .Include(offer => offer.LocalPropertyOfferData.NearMetroStations.Select(station => station.MetroBranchStation.MetroBranch))
                                        .Include(offer => offer.LocalPropertyOfferData.NearMetroStations.Select(station => station.MetroBranchStation.MetroStation))
                                        .Include(offer => offer.ExternalPropertyOfferData)
                                        .Include(offer => offer.PropertyExchangeDetails);

            if (reqQuery.MaxCost.HasValue)
            {
                query = query.Where(x => x.Cost <= reqQuery.MaxCost.Value);
            }

            if (reqQuery.MinCost.HasValue)
            {
                query = query.Where(x => x.Cost >= reqQuery.MinCost.Value);
            }

            if (reqQuery.RoomCount.HasValue)
            {
                query = query.Where(x => x.RoomCount == reqQuery.RoomCount.Value);
            }

            if (reqQuery.MetroIds != null && reqQuery.MetroIds.Any())
            {
                query = query.Where(x => x.LocalPropertyOfferData.NearMetroStations.Any(y => reqQuery.MetroIds.Contains(y.MetroBranchStationId)));
            }

            if (reqQuery.ViewPort != null)
            {
                var polygonStringDefinition = string.Format(
                    CultureInfo.InvariantCulture.NumberFormat,
                    "POLYGON(({0} {1}, {2} {3}, {4} {5}, {6} {7}, {8} {9}))",
                    reqQuery.ViewPort.LeftTopLon,
                    reqQuery.ViewPort.LeftTopLat,
                    reqQuery.ViewPort.LeftBottomLon,
                    reqQuery.ViewPort.LeftBottomLat,
                    reqQuery.ViewPort.RightBottomLon,
                    reqQuery.ViewPort.RightBottomLat,
                    reqQuery.ViewPort.RightTopLon,
                    reqQuery.ViewPort.RightTopLat,
                    reqQuery.ViewPort.LeftTopLon,
                    reqQuery.ViewPort.LeftTopLat);

                DbGeography polygon = DbGeography.PolygonFromText(polygonStringDefinition, CoordinateSystemId);
                query = query.Where(x => x.Location.Intersects(polygon));
            }

            List<PropertyOffer> offers = query.OrderByDescending(x => x.CreationDate)
                                              .Skip(reqQuery.Skip)
                                              .Take(reqQuery.Take)
                                              .ToList();

            return offers;
        }
    }
}