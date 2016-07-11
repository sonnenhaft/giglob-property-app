namespace Domain.Entities
{
    public interface IAggregateRootEntity<TId>
    {
         TId Id { get; set; }
    }
}