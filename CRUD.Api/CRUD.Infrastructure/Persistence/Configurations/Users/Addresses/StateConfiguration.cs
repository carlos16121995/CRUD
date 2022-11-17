using CRUD.Domain.Entities.Users.Addresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistence.Configurations.Users.Addresses
{
    internal class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
                .ToTable(nameof(State), nameof(Users))
                .HasKey((b) => b.UF);

            builder
                .Property((b) => b.UF)
                .HasMaxLength(2)
                .IsFixedLength()
                .IsUnicode(false);

            builder
                .Property((b) => b.Name)
                .IsRequired()
                .HasMaxLength(32)
                .IsUnicode(false);
        }
    }
}
