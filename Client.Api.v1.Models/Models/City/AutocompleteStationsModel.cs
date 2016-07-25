using Client.Api.v1.Models.Models.Common;

namespace Client.Api.v1.Models.Models.City
{
    /// <summary>
    /// Модель для автокомплита станций
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class AutocompleteStationsModel<T> : IdentifyModel<T>
    {
        /// <summary>
        /// Название станций
        /// </summary>
        public string StationName { get; set; }
    }
}