using System.Collections.Generic;
using Client.Api.v1.Models.Models.City;
using SwaggerResponseExampleModule.Providers.Interfaces;

namespace Client.Api.v1.Models.Models.Home.ResponseExamples
{
    public class DataModelResponseExample: ISwaggerResponseExampleProvider
    {
        public object GetResponseExample()
        {
            return new DataModel
            {
                Cities = new List<CityModel>
                {
                    new CityModel
                    {
                        Id = 1,
                        Title = "Город 1",
                        Districts = new List<DistrictModel>
                        {
                            new DistrictModel
                            {
                                Id = 1,
                                Title = "Район 1"
                            },
                            new DistrictModel
                            {
                                Id = 2,
                                Title = "Район 2"
                            }
                        }
                    },
                    new CityModel
                    {
                        Id = 2,
                        Title = "Город 2",
                        Districts = new List<DistrictModel>
                        {
                            new DistrictModel
                            {
                                Id = 3,
                                Title = "Район 1"
                            },
                            new DistrictModel
                            {
                                Id = 4,
                                Title = "Район 2"
                            }
                        }
                    }
                }
            };
        }
    }
}