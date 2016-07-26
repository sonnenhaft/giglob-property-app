using System;
using System.Collections.Generic;
using Domain.Entities.Implementation.PropertyOffer.Queries;

namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferGetAllOffersRequestModel
    {
        /// <summary>
        /// Ид города
        /// </summary>
        public long CityId { get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; }

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

        public ViewPort ViewPort { get; set; }
    }

    /// <summary>
    /// Видимая область на карте
    /// </summary>
    public class ViewPort
    {
        /// <summary>
        /// Верхная левая точка широты
        /// </summary>
        public double LeftTopLat { get; set; }

        /// <summary>
        /// Верхная левая точка долготы
        /// </summary>
        public double LeftTopLon { get; set; }

        /// <summary>
        /// Нижняя левая точка широты
        /// </summary>
        public double LeftBottomLat { get; set; }

        /// <summary>
        /// Нижняя левая точка долготы
        /// </summary>
        public double LeftBottomLon { get; set; }

        /// <summary>
        /// Верхная правая точка широты
        /// </summary>
        public double RightTopLat { get; set; }

        /// <summary>
        /// Верхная правая точка долготы
        /// </summary>
        public double RightTopLon { get; set; }

        /// <summary>
        /// Нижняя правая точка широты
        /// </summary>
        public double RightBottomLat { get; set; }

        /// <summary>
        /// Нижняя правая точка долготы
        /// </summary>
        public double RightBottomLon { get; set; }
    }



}