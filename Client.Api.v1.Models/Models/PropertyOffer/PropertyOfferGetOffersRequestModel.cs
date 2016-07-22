namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferGetOffersRequestModel
    {
        /// <summary>
        /// Ид города
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Номер страницы
        /// </summary>
        public int Page { get; set; }

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
        public long?[] MetroIds { get; set; }
    }
}