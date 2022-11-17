using CRUD.Domain.Enums;

namespace CRUD.Domain.Entities.Users.Addresses
{
    public class Address : BaseEntity<Guid>
    {
        public Guid UserId { get; set; }

        public int CityId { get; set; }

        public EAddressType AddressType { get; set; }

        public string ZipCode { get; set; } = string.Empty;

        public string Neighborhood { get; set; } = string.Empty;

        public string Street { get; set; } = string.Empty;

        public string Number { get; set; } = string.Empty;

        public string? Complement { get; set; }

        public virtual User? User { get; set; }

        public virtual City? City { get; set; }
    }
}
