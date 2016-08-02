using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Client.Api.v1.Models.Models.Common;
using Client.Api.v1.Models.Models.PropertyOffer;
using CQRS;
using Domain.Authentication;
using Domain.Entities.Implementation.PropertyOffer;
using Domain.Entities.Implementation.PropertyOffer.Commands;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
using Domain.Entities.Implementation.PropertyOffer.Queries;
using ExpressMapper.Extensions;

namespace Client.Api.v1.Facades
{
    public class PropertyOfferFacade
    {
        private readonly ICurrentUserService _currentUserService;

        private readonly ICommandHandler<PropertyOffer_CreateCommand> _propertyOfferCreateCommandHandler;
        private readonly IQueryHandler<Offer_GetAllQuery, IEnumerable<PropertyOffer>> _propertyOfferGetAllCommandHandler;
        private readonly IQueryHandler<PropertyOffer_GetUserOffersQuery, IEnumerable<PropertyOffer>> _propertyOfferGetUserOffersQueryHandler;
        private readonly IQueryHandler<PropertyOffer_GetQuery, PropertyOffer> _propertyOfferGetQueryHandler; 

        public PropertyOfferFacade(ICurrentUserService currentUserService, ICommandHandler<PropertyOffer_CreateCommand> propertyOfferCreateCommandHandler, IQueryHandler<Offer_GetAllQuery, IEnumerable<PropertyOffer>> propertyOfferGetAllCommandHandler, IQueryHandler<PropertyOffer_GetUserOffersQuery, IEnumerable<PropertyOffer>> propertyOfferGetUserOffersQueryHandler, IQueryHandler<PropertyOffer_GetQuery, PropertyOffer> propertyOfferGetQueryHandler)
        {
            _propertyOfferCreateCommandHandler = propertyOfferCreateCommandHandler;
            _propertyOfferGetAllCommandHandler = propertyOfferGetAllCommandHandler;
            _currentUserService = currentUserService;
            _propertyOfferGetUserOffersQueryHandler = propertyOfferGetUserOffersQueryHandler;
            _propertyOfferGetQueryHandler = propertyOfferGetQueryHandler;
        }

        public void Create(PropertyOfferCreateRequestModel reqModel)
        {
            _propertyOfferCreateCommandHandler.Handle(new PropertyOffer_CreateCommand(reqModel.Map<PropertyOfferCreateRequestModel, PropertyOfferCreateContext>()));
        }

        public IEnumerable<PropertyOfferListItemModel> GetAll(PropertyOfferGetAllOffersRequestModel req)
        {
            Offer_GetAllQuery query = req.Map<PropertyOfferGetAllOffersRequestModel,Offer_GetAllQuery>();

            IEnumerable<PropertyOffer> items = _propertyOfferGetAllCommandHandler.Handle(query);

            return items.Map<IEnumerable<PropertyOffer>, IEnumerable<PropertyOfferListItemModel>>();
        }

        public IEnumerable<PropertyOfferModel> GetCurrentUserOffers()
        {
            Contract.Requires(_currentUserService.IsAuthenticated());

            var offers = _propertyOfferGetUserOffersQueryHandler.Handle(new PropertyOffer_GetUserOffersQuery(_currentUserService.GetId()));

            return offers.Map<IEnumerable<PropertyOffer>, IEnumerable<PropertyOfferModel>>();
        }

        public PropertyOfferModel Get(PropertyOfferGetRequestModel reqModel)
        {
            return _propertyOfferGetQueryHandler.Handle(new PropertyOffer_GetQuery(reqModel.Id))
                                                .Map<PropertyOffer, PropertyOfferModel>();
        }
    }
}