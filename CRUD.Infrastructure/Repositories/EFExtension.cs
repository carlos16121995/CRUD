using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CRUD.Infrastructure.Repositories
{
    public static class EFExtension
    {
        public static async Task<TKey> InsertAsync<TEntity, TKey>(this DbContext context, TEntity entity)
            where TEntity : BaseEntity<TKey>
            where TKey : unmanaged
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public static async Task<bool> UpdateAsync<TEntity, TKey>(this DbContext context, Expression<Func<TEntity, bool>> where, Action<TEntity> _setEntity)
            where TEntity : BaseEntity<TKey>
            where TKey : unmanaged
        {
            var results = await context.Set<TEntity>()
                    .Where(where)
                    .ToListAsync();

            foreach (var entity in results)
            { _setEntity(entity); }

            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<bool> DeleteAsync<TEntity, TKey>(this DbContext context, Expression<Func<TEntity, bool>> where, Action<TEntity> setDelete)
            where TEntity : BaseEntity<TKey>
            where TKey : unmanaged
        {
            var search = await context.Set<TEntity>().FirstOrDefaultAsync(where);
            if (search is not null)
            {
                search.Delete();
                setDelete(search);
            }
            await context.SaveChangesAsync();
            return true;
        }

        public static async Task<bool> InactivateAsync<TEntity, TKey>(this DbContext context, Expression<Func<TEntity, bool>> where, Action<TEntity> setInactivate)
            where TEntity : BaseEntity<TKey>
            where TKey : unmanaged
        {
            var search = await context.Set<TEntity>().FirstOrDefaultAsync(where);
            if (search is not null)
            {
                search.Inactivate();
                setInactivate(search);
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
