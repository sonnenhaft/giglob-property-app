using System;
using System.Web;
using Domain.Authentication;
using Microsoft.AspNet.Identity;

namespace Client.Api.Authentication.Services.Implementation
{
    public class CurrentUserService: ICurrentUserService
    {
        public bool IsAuthenticated()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public long GetId()
        {
            if(!IsAuthenticated())
            {
                throw new Exception("User not authenticated");
            }

            return HttpContext.Current.User.Identity.GetUserId<long>();
        }
    }
}