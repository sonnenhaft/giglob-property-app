using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics.Contracts;
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
    }

    public class Offer_GetAllQueryHandler : IQueryHandler<Offer_GetAllQuery, IEnumerable<PropertyOffer>>
    {
        private readonly IPropertyOfferRepository _offerRepository;

        public Offer_GetAllQueryHandler(IPropertyOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public IEnumerable<PropertyOffer> Handle(Offer_GetAllQuery query)
        {
            var offers = _offerRepository.GetAll().Where(x => x.LocalPropertyOfferData.CityId == query.CityId).OrderBy(x=>x.CreationDate)
                .Skip(query.Take * query.Page).Take(query.Take).ToList();

            return offers;
        }
    }

}