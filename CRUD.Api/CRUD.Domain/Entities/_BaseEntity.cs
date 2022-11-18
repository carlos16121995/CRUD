namespace CRUD.Domain.Entities
{
    public class BaseEntity<TKey> : BaseEntityWithoutId
    {
        public TKey Id { get; set; }
    }
    public class BaseEntityWithoutId
    {
        public bool Activated { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public DateTime UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual void Delete()
        {
            Activated = false;
            Deleted = true;
            UpdatedAt = DateTime.UtcNow;
        }
        public virtual void Inactivate()
        {
            Activated = !Activated;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
