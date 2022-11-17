using CRUD.Domain.Entities.Users;
using CRUD.Domain.Entities.Users.Addresses;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure.Persistence
{
    public partial class Context
    {
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;
    }
}
