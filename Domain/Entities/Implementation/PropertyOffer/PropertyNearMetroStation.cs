using Domain.Entities.Implementation.City;

namespace Domain.Entities.Implementation.Property
{
    public class PropertyNearMetroStation
    {
        public long Id { get; set; }

        public long PropertyId { get; set; }

        public long MetroStationId { get; set; }

        public long? MetroBranchId { get; set; }

        public virtual MetroStation MetroStation { get; set; }

        public virtual MetroBranch MetroBranch { get; set; }
    }
}