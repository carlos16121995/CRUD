using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistence.Configurations.Users
{
    using CRUD.Domain.Entities.Users;
    using CRUD.Infrastructure.Persistence.Configurations;

    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .ToTable(nameof(User), nameof(Users));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
                .Property((b) => b.Name)
                .HasMaxLength(64)
                .IsUnicode(false);

            builder
                .Property(e => e.BirthDate)
                .HasDefaultValueSql("GetUtcDate()");

            builder
                .Configure();
        }
    }
}
