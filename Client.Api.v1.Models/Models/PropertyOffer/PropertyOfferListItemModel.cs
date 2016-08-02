using System;
using System.Collections.Generic;
using Client.Api.v1.Models.Models.City;
using Domain.Entities.Implementation.PropertyOffer;

namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferListItemModel
    {
        public long Id { get; set; }

        public decimal Cost { get; set; }

        public string StreetName { get; set; }

        public int Level { get; set; }

        public double AreaSize { get; set; }

        public int RoomCount { get; set; }

        public List<string> Photos { get; set; }

        /// <summary>
        /// Широта
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// Ближайшая станция метро
        /// </summary>
        public NearMetroStationModel NearMetroStationModel { get; set; }
    }
}