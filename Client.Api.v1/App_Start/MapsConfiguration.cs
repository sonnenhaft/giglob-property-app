<<<<<<< HEAD
﻿using Client.Api.v1.Models.Models.User;
using Domain.Entities.User.Implementation;
=======
﻿using Client.Api.v1.Models.Models.City;
using Domain.Entities.Implementation.City;
>>>>>>> dev
using ExpressMapper;

namespace Client.Api.v1
{
    public class MapsConfiguration
    {
        public static void Configure()
        {
<<<<<<< HEAD
            Mapper.Register<User, UserModel>();
=======
            Mapper.Register<City, CityModel>();
>>>>>>> dev
        }
    }
}