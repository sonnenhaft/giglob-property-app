using Client.Api.Authentication.Services;
using Client.Api.Authentication.Stores;
using Domain.Entities.User.Implementation;
using Domain.Entities.User.Services;
using Microsoft.AspNet.Identity;
using SimpleInjector;

namespace Client.Api.Authentication.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterClientApiAuthenticationDependencies(this Container container)
        {
            container.Register<IUserAuthorizationService, UserAuthorizationService>();
            container.Register(typeof(IUserStore<User, long>), typeof(UserStore), Lifestyle.Transient);
        }
    }
}