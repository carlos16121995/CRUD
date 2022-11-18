using CRUD.Domain.Entities.Users.Addresses;
using CRUD.Domain.Enums;

namespace CRUD.Domain.Entities.Users
{
    public class User : BaseEntity<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public EGender Gender { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
