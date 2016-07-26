using System;
using System.Collections.Generic;

namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferGetAllOffersRequestModel
    {
        /// <summary>
        /// Ид города
        /// </summary>
        public long CityId { get; set; }

        /// <summary>
        /// Кол-во эл-в для пропуска
        /// </summary>
        public int Skip { get; set; }

        /// <summary>
        /// Кол-во записей для получения
        /// </summary>
        public int Take { get; set; }

        /// <summary>
        /// Стоимость От
        /// </summary>
        public decimal? MinCost { get; set; }

        /// <summary>
        /// Стоимость До
        /// </summary>
        public decimal? MaxCost { get; set; }

        /// <summary>
        /// Кол-во комнат
        /// </summary>
        public int? RoomCount { get; set; }

        /// <summary>
        /// Ид метро
        /// </summary>
        public IEnumerable<long> MetroIds { get; set; }
    }
}