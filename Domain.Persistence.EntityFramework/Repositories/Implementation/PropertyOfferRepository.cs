using System.Data.Entity;
using Domain.Entities.Implementation.PropertyOffer;
using Domain.Repositories;

namespace Domain.Persistence.EntityFramework.Repositories.Implementation
{
    public class PropertyOfferRepository: DeletableEntityFrameworkRepository<PropertyOffer, long>, IPropertyOfferRepository
    {
        public PropertyOfferRepository(DbContext dbContext, IRepository<PropertyOffer, long> decoratee) : base(dbContext, decoratee) { }
    }
}