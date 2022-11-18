using CRUD.Application;
using CRUD.Infrastructure.Persistence;
using CRUD.Test.Core.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Globalization;

namespace CRUD.Test.Tests
{
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

            provider.SeedInMemoryDatabase();
        }

        public static void ConfigureHost(IHostBuilder hostBuilder)
            => hostBuilder.ConfigureHostConfiguration((cb)
                => cb.AddJsonFile("appsettings.json"));
    }
}
