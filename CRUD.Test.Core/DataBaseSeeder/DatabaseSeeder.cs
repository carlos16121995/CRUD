using CRUD.Test.Core.DataBaseSeeder.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CRUD.Test.Core.DataBaseSeeder
{
    public static class DatabaseSeeder
    {
        public static void InitializeDatabase<TContext, TSeeder>(this IServiceProvider provider)
            where TContext : DbContext
            where TSeeder : class
        {
            var mappingInterface = typeof(IDatabaseSeed<>);

            var mappingTypes = typeof(TSeeder)?.GetTypeInfo()?.Assembly?.GetTypes()?
                .Where(x => x.GetInterfaces().Any(y => y.GetTypeInfo().IsGenericType
                        && y.GetGenericTypeDefinition() == mappingInterface))
                .ToList();

            var context = provider.GetRequiredService<TContext>();

            context.Database.EnsureDeleted();

            if (context.Database.IsRelational())
            {
                context.Database.SetCommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds);

                context.Database.Migrate();
            }

            mappingTypes = mappingTypes!
                .OrderBy((mt) =>
                {
                    var instancia = Activator.CreateInstance(mt);
                    ; var ordemSTR = instancia.GetType().GetProperty("Ordem").GetValue(instancia).ToString();

                    _ = int.TryParse(ordemSTR, out var ordemINT);

                    return ordemINT;
                })
                .ToList();

            foreach (var mt in mappingTypes)
            {
                var mapper = Activator.CreateInstance(mt);

                ((Task)(mapper?.GetType()?.GetMethod("Run").Invoke(mapper, new[] { context }))).Wait();
            }
        }
    }

}
