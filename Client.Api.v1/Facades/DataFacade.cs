using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Api.v1.Models.Models.City;
using Client.Api.v1.Models.Models.Home;
using CQRS;
using Domain.Entities.Implementation.City;
using Domain.Entities.Implementation.City.Queries;
using ExpressMapper.Extensions;

namespace Client.Api.v1.Facades
{
    public class DataFacade
    {
        private readonly IQueryHandler<City_GetAllQuery, IEnumerable<City>> _cityGetAllQueryHandler;

        public DataFacade(IQueryHandler<City_GetAllQuery, IEnumerable<City>> cityGetAllQueryHandler)
        {
            _cityGetAllQueryHandler = cityGetAllQueryHandler;
        }

        public DataModel GetData()
        {
            var query = _cityGetAllQueryHandler.Handle(new City_GetAllQuery());

            var model = new DataModel
            {
                Cities = query.Map<IEnumerable<City>, IEnumerable<CityModel>>()
            };

            return model;
        }
    }
}