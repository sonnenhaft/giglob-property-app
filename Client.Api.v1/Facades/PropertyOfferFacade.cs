using Client.Api.v1.Models.Models.Common;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using Client.Api.v1.Models.Models.PropertyOffer;
using CQRS;
using Domain.Authentication;
using Domain.Entities.Implementation.PropertyOffer;
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
        private readonly IQueryHandler<PropertyOffer_GetUserOffersQuery, IEnumerable<PropertyOffer>> _propertyOfferGetUserOffersQueryHandler;

        public PropertyOfferFacade(ICurrentUserService currentUserService, ICommandHandler<PropertyOffer_CreateCommand> propertyOfferCreateCommandHandler, IQueryHandler<PropertyOffer_GetUserOffersQuery, IEnumerable<PropertyOffer>> propertyOfferGetUserOffersQueryHandler)
        {
            _propertyOfferCreateCommandHandler = propertyOfferCreateCommandHandler;
            _currentUserService = currentUserService;
            _propertyOfferGetUserOffersQueryHandler = propertyOfferGetUserOffersQueryHandler;
        }

        public void Create(PropertyOfferCreateRequestModel reqModel)
        {
            _propertyOfferCreateCommandHandler.Handle(new PropertyOffer_CreateCommand(reqModel.Map<PropertyOfferCreateRequestModel, PropertyOfferCreateContext>()));
        }

        public IEnumerable<PropertyOfferModel> GetCurrentUserOffers()
        {
            Contract.Requires(_currentUserService.IsAuthenticated());

            var offers = _propertyOfferGetUserOffersQueryHandler.Handle(new PropertyOffer_GetUserOffersQuery(_currentUserService.GetId()));

            return offers.Map<IEnumerable<PropertyOffer>, IEnumerable<PropertyOfferModel>>();
        }
    }
}