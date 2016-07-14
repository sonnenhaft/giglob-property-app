using System;
using Microsoft.AspNet.Identity;

namespace Domain.Entities.User.Implementation
{
    public class User: IUser<long>, IAggregateRootEntity<long>
    {
        public long Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool EmailIsConfirmed { get; set; }

        public Guid? EmailConfirmationToken { get; set; }
    }
}