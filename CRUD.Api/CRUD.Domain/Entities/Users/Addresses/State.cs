namespace CRUD.Domain.Entities.Users.Addresses
{
    public class State : BaseEntityWithoutId
    {
        public string UF { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}
