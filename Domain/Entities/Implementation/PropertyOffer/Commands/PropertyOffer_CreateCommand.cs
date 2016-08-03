using CQRS;
using Domain.Entities.Implementation.PropertyOffer.Dtos;
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

        public PropertyOffer_CreateCommandHandler(IPropertyOfferRepository propertyOfferRepository)
        {
            _propertyOfferRepository = propertyOfferRepository;
        }

        public void Handle(PropertyOffer_CreateCommand command)
        {
            var offer = command.CreateContext.Map<PropertyOfferCreateContext, PropertyOffer>();
            _propertyOfferRepository.Add(offer);
        }
    }
}