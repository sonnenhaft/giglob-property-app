namespace Client.Api.v1.Models.Models.PropertyOffer
{
    public class PropertyOfferCreateNearMetroStationRequestModel
    {
        /// <summary>
        /// Идентификатор станции метро
        /// </summary>
        public long MetroStationId { get; set; }

        /// <summary>
        /// Идентификатор ветки метро
        /// </summary>
        public long MetroBranchId { get; set; }
    }
}