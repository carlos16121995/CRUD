using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infrastructure.Persistence.Configurations
{
    internal static class BaseEntityConfiguration
    {
        internal static void Configure<T>(this EntityTypeBuilder<T> builder)
           where T : BaseEntityWithoutId
        {
            builder
               .Property(e => e.UpdatedAt)
               .HasDefaultValueSql("GetUtcDate()")
               .ValueGeneratedOnAdd();

            builder
               .Property(e => e.CreatedAt)
               .HasDefaultValueSql("GetUtcDate()")
               .ValueGeneratedOnAdd();
        }
    }
}
