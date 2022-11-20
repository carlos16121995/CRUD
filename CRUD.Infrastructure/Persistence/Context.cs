using CRUD.Infrastructure.Persistence.Configurations.Users;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Infrastructure.Persistence
{
    public partial class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {
            if (opcoes is null)
                throw new ArgumentNullException(nameof(opcoes));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly,
                    (type) => (type.Namespace ?? "").Contains("Configurations"));
        }
    }
}
