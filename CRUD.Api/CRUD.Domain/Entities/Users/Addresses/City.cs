namespace CRUD.Domain.Entities.Users.Addresses
{
    public class City : BaseEntity<int>
    {
        public string Name { get; set; } = string.Empty;

        public string UF { get; set; } = string.Empty;

        public virtual State? State { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
