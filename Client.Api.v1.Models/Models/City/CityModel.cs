using System.Collections.Generic;

namespace Client.Api.v1.Models.Models.City
{
    /// <summary>
    ///     Модель города
    /// </summary>
    public class CityModel
    {
        /// <summary>
        ///     Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        ///     Название
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Районы
        /// </summary>
        public IEnumerable<DistrictModel> Districts { get; set; }
    }
}