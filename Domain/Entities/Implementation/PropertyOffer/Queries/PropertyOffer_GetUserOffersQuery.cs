using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using CQRS;
using Domain.Repositories;

namespace Domain.Entities.Implementation.PropertyOffer.Queries
{
    public class PropertyOffer_GetUserOffersQuery : IQuery
    {
        public long UserId { get; set; }

        public PropertyOffer_GetUserOffersQuery(long userId)
        {
            UserId = userId;
        }
    }

    public class PropertyOffer_GetUserOffersQueryHandler : IQueryHandler<PropertyOffer_GetUserOffersQuery, IEnumerable<PropertyOffer>>
    {
        private readonly IPropertyOfferRepository _propertyOfferRepository;

        public PropertyOffer_GetUserOffersQueryHandler(IPropertyOfferRepository propertyOfferRepository)
        {
            _propertyOfferRepository = propertyOfferRepository;
        }

        public IEnumerable<PropertyOffer> Handle(PropertyOffer_GetUserOffersQuery query)
        {
            Contract.Requires(query != null);

            var offers = _propertyOfferRepository.GetAll()
                                                 .Where(x => x.IsLocal && x.LocalPropertyOfferData.OwnerId == query.UserId);

            return offers;
        }
    }
}