using Microsoft.EntityFrameworkCore;

namespace CRUD.Test.Core.DataBaseSeeder.Abstractions
{
    public interface IDatabaseSeed<TContext> where TContext : DbContext
    {
        int Ordem { get; }
        int TotalItems { get; }
        Task Run(TContext context);
    }
}
