﻿namespace Domain.Entities.Implementation.PropertyOffer.Dtos
{
    public class PropertyOfferExchangeContext
    {
        /// <summary>
        ///     Идентификатор города
        /// </summary>
        public long CityId { get; set; }

        /// <summary>
        ///     Идентификатор района
        /// </summary>
        public long? DistrictId { get; set; }

        /// <summary>
        ///     Количество комнат
        /// </summary>
        public int RoomCount { get; set; }

        /// <summary>
        ///     Площадь недвижимости
        /// </summary>
        public double AreaSize { get; set; }

        /// <summary>
        ///     Стоимость "От"
        /// </summary>
        public decimal MinCost { get; set; }

        /// <summary>
        ///     Стоимость "До"
        /// </summary>
        public decimal MaxCost { get; set; }
    }
}