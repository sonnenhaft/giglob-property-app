namespace Domain.Entities.Implementation
{
    public class City: IAggregateRootEntity<long>
    {
        public long Id { get; set; }

        public string Title { get; set; }
    }
}