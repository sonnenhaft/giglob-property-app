using Client.Api.v1.Models.Models.PropertyOffer;
using CQRS;
using Domain.Entities.Implementation.PropertyOffer.Commands;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
using ExpressMapper.Extensions;

namespace Client.Api.v1.Facades
{
    public class PropertyOfferFacade
    {
        private readonly ICommandHandler<PropertyOffer_CreateCommand> _propertyOfferCreateCommandHandler;

        public PropertyOfferFacade(ICommandHandler<PropertyOffer_CreateCommand> propertyOfferCreateCommandHandler)
        {
            _propertyOfferCreateCommandHandler = propertyOfferCreateCommandHandler;
        }

        public void Create(PropertyOfferCreateRequestModel reqModel)
        {
            _propertyOfferCreateCommandHandler.Handle(new PropertyOffer_CreateCommand(reqModel.Map<PropertyOfferCreateRequestModel, PropertyOfferCreateContext>()));
        }
    }
}