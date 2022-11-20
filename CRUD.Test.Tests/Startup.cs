using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;
using Xunit;

[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly)]
namespace CRUD.Test.Tests
{
    using CRUD.Application;
    using CRUD.Infrastructure.Persistence;
    using CRUD.Test.Core.DataBaseSeeder;
    using CRUD.Test.Core.Extensions;
    using CRUD.Test.Core.Seeders.Localities;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.DependencyInjection.Extensions;

    public static class Startup
    {
        public static void ConfigureServices(IServiceCollection services, HostBuilderContext hostBuilder)
        {
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
            services.RegisterDatabase<Context>();

            services.AddApplicationServices(hostBuilder.Configuration);
            IServiceProvider provider = services
                                            .BuildServiceProvider();

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            provider.InitializeDatabase<Context, StateSeeder>();

            services.AddHttpContextAccessor()
                        .TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
