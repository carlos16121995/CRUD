using CRUD.Domain.Entities.Users.Addresses;
using CRUD.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistence.Configurations.Users.Addresses
{
    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder
                .ToTable(nameof(Address), nameof(Users));

            builder.Property(e => e.Id)
                .HasDefaultValueSql("NEWSEQUENTIALID()");

            builder
               .Property((b) => b.ZipCode)
               .HasMaxLength(8)
               .IsUnicode(false);

            builder
               .Property((b) => b.Neighborhood)
               .HasMaxLength(60)
               .IsRequired()
               .IsUnicode(false);

            builder
               .Property((b) => b.Street)
               .HasMaxLength(60)
               .IsRequired()
               .IsUnicode(false);

            builder
               .Property((b) => b.Number)
               .HasMaxLength(60)
               .IsRequired()
               .IsUnicode(false);

            builder
               .Property((b) => b.Complement)
               .HasMaxLength(60)
               .IsUnicode(false);

            builder
                .HasOne(address => address.User)
                .WithMany(user => user.Addresses);

            builder
                .HasOne(address => address.City)
                .WithMany(city => city.Addresses);

            builder
                .Configure();
        }
    }
}