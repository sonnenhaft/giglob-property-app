using System.Collections.Generic;
using Client.Api.v1.Models.Models.PropertyOffer;
using CQRS;
using Domain.Entities.Implementation.PropertyOffer;
using Domain.Entities.Implementation.PropertyOffer.Commands;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
using Domain.Entities.Implementation.PropertyOffer.Queries;
using ExpressMapper.Extensions;

namespace Client.Api.v1.Facades
{
    public class PropertyOfferFacade
    {
        private readonly ICommandHandler<PropertyOffer_CreateCommand> _propertyOfferCreateCommandHandler;
        private readonly IQueryHandler<Offer_GetAllQuery, IEnumerable<PropertyOffer>> _propertyOfferGetAllCommandHandler;

        public PropertyOfferFacade(ICommandHandler<PropertyOffer_CreateCommand> propertyOfferCreateCommandHandler,
                                   IQueryHandler<Offer_GetAllQuery, IEnumerable<PropertyOffer>> propertyOfferGetAllCommandHandler)
        {
            _propertyOfferCreateCommandHandler = propertyOfferCreateCommandHandler;
            _propertyOfferGetAllCommandHandler = propertyOfferGetAllCommandHandler;
        }

        public void Create(PropertyOfferCreateRequestModel reqModel)
        {
            _propertyOfferCreateCommandHandler.Handle(new PropertyOffer_CreateCommand(reqModel.Map<PropertyOfferCreateRequestModel, PropertyOfferCreateContext>()));
        }

        public IEnumerable<PropertyOfferDataModel> GetAll(PropertyOfferGetAllOffersRequestModel req)
        {
            Offer_GetAllQuery query = req.Map<PropertyOfferGetAllOffersRequestModel,Offer_GetAllQuery>();

            IEnumerable<PropertyOffer> items = _propertyOfferGetAllCommandHandler.Handle(query);

            return items.Map<IEnumerable<PropertyOffer>, IEnumerable<PropertyOfferDataModel>>();
        }
    }
}