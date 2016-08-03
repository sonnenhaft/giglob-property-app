namespace Domain.Entities
{
    public interface IDeletableEntity
    {
        bool IsDeleted { get; set; }
    }
}