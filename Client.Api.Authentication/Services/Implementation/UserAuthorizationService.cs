using System;
using System.Security.Claims;
using System.Text.RegularExpressions;
using Domain.Entities.Implementation.User;
using Domain.Entities.Implementation.User.Services;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Infrastructure;
using Microsoft.Owin.Security;

namespace Client.Api.Authentication.Services.Implementation
{
    public class UserAuthorizationService : IUserAuthorizationService
    {
        private readonly UserManager<User, long> _userManager;

        public UserAuthorizationService(UserManager<User, long> userManager)
        {
            _userManager = userManager;
        }

        public User Register(string email, string password)
        {
            email = PrepareEmail(email);

            var user = new User
                       {
                           Email = email,
                           UserName = email
                       };

            _userManager.Create(user, password);

            return user;
        }

        public string GenerateAccessToken(string userName, string password)
        {
            userName = PrepareEmail(userName);

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Incorrect username or password");
            }
            var userIdentity = _userManager.Find(userName, password);

            if (userIdentity == null)
            {
                throw new ArgumentException("Incorrect username or password");
            }

            var identity = new ClaimsIdentity(AuthConfiguration.OAuthBearerOptions.AuthenticationType);
            identity.AddClaim(new Claim(ClaimTypes.Name, userName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userIdentity.Id.ToString()));
            AuthenticationTicket ticket = new AuthenticationTicket(identity, new AuthenticationProperties());
            var currentUtc = new SystemClock().UtcNow;
            ticket.Properties.IssuedUtc = currentUtc;
            ticket.Properties.ExpiresUtc = currentUtc.Add(TimeSpan.FromDays(30));
            var accessToken = AuthConfiguration.OAuthBearerOptions.AccessTokenFormat.Protect(ticket);

            return accessToken;
        }

        public bool Check(string userName, string password)
        {
            return _userManager.Find(userName, password) != null;
        }

        private string PrepareEmail(string email)
        {
            return Regex.Replace(email, @"^([^@]+)", x => x.Groups[1].Value.Replace(".", ""))
                        .ToLower();
        }
    }
}