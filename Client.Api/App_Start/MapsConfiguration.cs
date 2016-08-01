using Domain.Authentication;
using ExpressMapper;

namespace Client.Api
{
    public class MapsConfiguration
    {
        public static void Configure(ICurrentUserService currentUserService)
        {
            v1.MapsConfiguration.Configure();
            Domain.MapsConfiguration.Configure(currentUserService);
            Mapper.Compile();
        }
    }
}