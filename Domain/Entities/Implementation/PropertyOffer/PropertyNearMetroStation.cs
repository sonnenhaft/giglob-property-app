using Domain.Entities.Implementation.City;

namespace Domain.Entities.Implementation.PropertyOffer
{
    public class PropertyNearMetroStation
    {
        public long Id { get; set; }

        public long PropertyOfferId { get; set; }

        public long MetroBranchStationId { get; set; }

        public virtual MetroBranchStation MetroBranchStation { get; set; }
    }
}