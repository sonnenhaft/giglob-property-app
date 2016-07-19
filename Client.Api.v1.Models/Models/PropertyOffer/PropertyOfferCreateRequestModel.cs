using System;
using System.Collections.Generic;
using Domain.Entities.Implementation.Property;
using Domain.Entities.Implementation.Property.Enums;

namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferCreateRequestModel
    {
        /// <summary>
        /// Идентификатор города
        /// </summary>
        public long CityId { get; set; }

        /// <summary>
        /// Идентификатор района
        /// </summary>
        public long? DistrictId { get; set; }

        /// <summary>
        /// Идентификаторы ближайших станций метро
        /// </summary>
        public IEnumerable<PropertyNearMetroStation> NearMetroStations { get; set; }

        /// <summary>
        /// Название улицы
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public string ApartmentNumber { get; set; }

        /// <summary>
        /// Широта
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// Этаж
        /// </summary>
        public int Level { get; set; }
        
        /// <summary>
        /// Площадь недвижимости
        /// </summary>
        public double AreaSize { get; set; }

        /// <summary>
        /// Количество комнат
        /// </summary>
        public int RoomCount { get; set; }

        /// <summary>
        /// Тип недвижимости. NewBuilding = 1, Resale = 2
        /// </summary>
        public PropertyType Type { get; set; }

        /// <summary>
        /// Категория строения. Flat = 1, House = 2
        /// </summary>
        public BuildingCategory BuildingCategory { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Тип предложения. Sale = 1, Exchange = 2
        /// </summary>
        public OfferType OfferType { get; set; }

        /// <summary>
        /// Фотографии недвижимости
        /// </summary>
        public IEnumerable<PropertyOfferCreatePhotoRequestModel> Photoes { get; set; }
        
        /// <summary>
        /// Документы
        /// </summary>
        public IEnumerable<Guid> Documents { get; set; }
    }
}