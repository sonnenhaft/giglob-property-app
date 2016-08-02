using System;
using CQRS;
using Domain.Exceptions;
using Domain.Repositories;

namespace Domain.Entities.Implementation.PropertyOffer.Queries
{
    public class PropertyOffer_GetQuery: IQuery
    {
        public PropertyOffer_GetQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }

    public class PropertyOffer_GetQueryHandler: IQueryHandler<PropertyOffer_GetQuery, PropertyOffer>
    {
        private readonly IPropertyOfferRepository _propertyOfferRepository;

        public PropertyOffer_GetQueryHandler(IPropertyOfferRepository propertyOfferRepository)
        {
            _propertyOfferRepository = propertyOfferRepository;
        }

        public PropertyOffer Handle(PropertyOffer_GetQuery query)
        {
            var offer = _propertyOfferRepository.Get(query.Id);

            if (offer == null)
            {
                throw new NotFoundException("Property offer not found");
            }

            return offer;
        }
    }
}