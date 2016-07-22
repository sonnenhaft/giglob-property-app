using System;
using System.Collections.Generic;
using Domain.Entities.Implementation.PropertyOffer;

namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferDataModel
    {
        public long Id { get; set; }

        public decimal Cost { get; set; }

        public string StreetName { get; set; }

        public string HouseNumber { get; set; }

        public string Housing { get; set; }

        public string ApartmentNumber { get; set; }

        public int Level { get; set; }

        public double AreaSize { get; set; }

        public int RoomCount { get; set; }

        public List<string> Photoes { get; set; }
    }
}