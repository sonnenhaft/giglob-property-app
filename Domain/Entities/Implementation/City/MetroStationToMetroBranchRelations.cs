namespace Domain.Entities.Implementation.City
{
    public class MetroStationToMetroBranchRelations
    {
        public long MetroStationId { get; set; }

        public virtual MetroStation MetroStation { get; set; }

        public long MetroBranchId { get; set; }

        public virtual MetroBranch MetroBranch { get; set; }
    }
}