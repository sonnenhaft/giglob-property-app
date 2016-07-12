using Microsoft.AspNet.Identity;

namespace Domain.Entities.Implementation
{
    public class User: IUser<long>, IAggregateRootEntity<long>
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}