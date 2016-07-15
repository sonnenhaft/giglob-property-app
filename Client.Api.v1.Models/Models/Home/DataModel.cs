using System.Collections.Generic;
using Client.Api.v1.Models.Models.City;

namespace Client.Api.v1.Models.Models.Home
{
    /// <summary>
    /// Модель данных для выгрузки
    /// </summary>
    public class DataModel
    {
        /// <summary>
        /// Города
        /// </summary>
        public IEnumerable<CityModel> Cities { get; set; }
    }
}