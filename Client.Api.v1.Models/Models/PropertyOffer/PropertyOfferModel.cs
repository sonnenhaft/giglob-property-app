using System;
using System.Collections.Generic;
using Client.Api.v1.Models.Models.City;
using Domain.Entities.Implementation.PropertyOffer.Enums;

namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferModel
    {
        /// <summary>
        /// Идентификатор города, если есть
        /// </summary>
        public long? CityId { get; set; }

        /// <summary>
        /// Название города
        /// </summary>
        public string CityName { get; set; }

        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Идентификатор района, если есть
        /// </summary>
        public long? DistrictId { get; set; }

        /// <summary>
        /// Название района
        /// </summary>
        public string DistrictName { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Cost { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Дата публикации
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Тип предложения. Sale = 1, Exchange = 2
        /// </summary>
        public OfferType OfferType { get; set; }

        /// <summary>
        /// Широта
        /// </summary>
        public double Lat { get; set; }

        /// <summary>
        /// Долгота
        /// </summary>
        public double Lon { get; set; }

        /// <summary>
        /// Название улицы
        /// </summary>
        public string StreetName { get; set; }

        /// <summary>
        /// Номер дома
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Корпус дома
        /// </summary>
        public string Housing { get; set; }

        /// <summary>
        /// Номер квартиры
        /// </summary>
        public string ApartmentNumber { get; set; }

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
        /// Владелец загрузил документы на объект недвижимости
        /// </summary>
        public bool OwnerUploadedDocuments { get; set; }

        /// <summary>
        /// Тип недвижимости. NewBuilding = 1, Resale = 2
        /// </summary>
        public PropertyType Type { get; set; }

        /// <summary>
        /// Категория здания. Flat = 1, House = 2
        /// </summary>
        public BuildingCategory? BuildingCategory { get; set; }

        /// <summary>
        /// Ближайшая станция метро
        /// </summary>
        public NearMetroStationModel NearMetroStationModel { get; set; }

        /// <summary>
        /// Ссылки на фотографии объекта недвижимости
        /// </summary>
        public IEnumerable<string> PhotoUrls { get; set; }
    }
}