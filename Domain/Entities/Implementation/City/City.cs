namespace Domain.Entities.Implementation.City
{
    public class City: IAggregateRootEntity<long>
    {
        public long Id { get; set; }

        public string Name { get; set; }
    }
}