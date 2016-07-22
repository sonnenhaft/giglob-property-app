﻿using System.Collections.Generic;
using System.Linq;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.PropertyOffer.Queries
{
    public class Offer_GetAllQuery : IQuery
    {
        public long CityId { get; set; }

        public int Take { get { return 300; } }

        public int Page { get; set; }

        /// <summary>
        /// Стоимость От
        /// </summary>
        public decimal? MinCost { get; set; }

        /// <summary>
        /// Стоимость До
        /// </summary>
        public decimal? MaxCost { get; set; }

        /// <summary>
        /// Кол-во комнат
        /// </summary>
        public int? RoomCount { get; set; }

        /// <summary>
        /// Ид метро
        /// </summary>
        public long?[] MetroIds { get; set; }
    }

    public class Offer_GetAllQueryHandler : IQueryHandler<Offer_GetAllQuery, IEnumerable<PropertyOffer>>
    {
        private readonly IPropertyOfferRepository _offerRepository;

        public Offer_GetAllQueryHandler(IPropertyOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IEnumerable<PropertyOffer> Handle(Offer_GetAllQuery reqQuery)
        {
            var query = _offerRepository.GetAll().Where(x => x.LocalPropertyOfferData.CityId == reqQuery.CityId);

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

            if (reqQuery.MetroIds != null)
            {
                query = query.Where(x => x.LocalPropertyOfferData.NearMetroStations.Any(y=> reqQuery.MetroIds.Contains(y.MetroStationId)));
            }

            List<PropertyOffer> offers = query.OrderBy(x => x.CreationDate)
                .Skip(reqQuery.Take * (reqQuery.Page - 1))
                .Take(reqQuery.Take).ToList();

            return offers;
        }
    }

}