using System.Collections.Generic;
using Client.Api.v1.Models.Models.City;
using SwaggerResponseExampleModule.Providers.Interfaces;

namespace Client.Api.v1.Models.Models.Home.ResponseExamples
{
    public class StationModelResponseExample : ISwaggerResponseExampleProvider
    {
        public object GetResponseExample()
        {
            return new StationModel
            {
                Stations = new List<NearMetroStationModel>
                {
                    new NearMetroStationModel
                    {
                        Id = 1,
                        Name = "Город 1",
                        HexColor = "ffd803",
                        MetroBranchId = 1
                    },
                     new NearMetroStationModel
                    {
                        Id = 2,
                        Name = "Город 2",
                        HexColor = "b61d8e",
                        MetroBranchId = 22
                    }
                }
            };
        }
    }
}