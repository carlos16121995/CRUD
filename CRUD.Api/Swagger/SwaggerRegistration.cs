// Copyright (c) 2022, Unidas. All rights reserved
// PRIVATE SOURCE. Any kind of unauthorized use is prohibited.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace CRUD.Api.Swagger
{
    /// <summary>
    /// 
    /// </summary>
    public static class SwaggerRegistration
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services, IConfiguration configuration)
        {
            var swaggerConfiguration = new SwaggerConfiguration();
            configuration.Bind("SwaggerConfiguration", swaggerConfiguration);
            ValidateSwaggerConfiguration(swaggerConfiguration);

            services.AddTransient(typeof(SwaggerConfiguration), (_) => swaggerConfiguration);
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            services.AddApiVersioning(options =>
            {
                // Retorna os headers "api-supported-versions" e "api-deprecated-versions"
                // indicando versões suportadas pela API e o que está como deprecated
                options.ReportApiVersions = true;

                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(swaggerConfiguration.Version, 0);
            });
            services.AddVersionedApiExplorer(options =>
            {
                // Agrupar por número de versão
                options.GroupNameFormat = "'v'VVV";

                // Necessário para o correto funcionamento das rotas
                options.SubstituteApiVersionInUrl = true;
            });

            services.AddSwaggerGen(cfg =>
            {
                cfg.DocumentFilter<SwaggerEnumDescriptions>();
                cfg.OperationFilter<SwaggerHeaderAttribute>();
                cfg.OrderActionsBy((apiDesc) => $"{apiDesc.ActionDescriptor.RouteValues["controller"]}_{apiDesc.RelativePath}");

                var xmlFile = $"{Assembly.Load(swaggerConfiguration.AssembliesBasePath + ".Api").GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);

                xmlFile = $"{Assembly.Load(swaggerConfiguration.AssembliesBasePath + ".Application").GetName().Name}.xml";
                xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                cfg.IncludeXmlComments(xmlPath);

                cfg.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Concatene a palavra Bearer, um espaço em branco e o token de acesso: (Bearer {token})",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                cfg.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }});
                cfg.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            return services;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseSwaggerDocumentation(this WebApplication app)
        {
            var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            app.UseSwaggerPageAuthorization();
            app.UseSwagger(opt =>
            {
                opt.PreSerializeFilters.Add((swagger, httpReq) =>
                {
                    swagger.Servers.Clear();
                });
            });
            app.UseSwaggerUI(cfg =>
            {
                foreach (var description in provider.ApiVersionDescriptions)
                    cfg.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                        description.GroupName.ToUpperInvariant());
            });
            return app;
        }

        private static IApplicationBuilder UseSwaggerPageAuthorization(this IApplicationBuilder builder)
            => builder.UseMiddleware<SwaggerAuthorization>();

        private static void ValidateSwaggerConfiguration(SwaggerConfiguration config)
        {
            List<string> missingConfig = new();

            if (string.IsNullOrWhiteSpace(config.Login))
                missingConfig.Add(nameof(config.Login));

            if (string.IsNullOrWhiteSpace(config.Password))
                missingConfig.Add(nameof(config.Password));

            if (string.IsNullOrWhiteSpace(config.PageDisplayName))
                missingConfig.Add(nameof(config.PageDisplayName));

            if (string.IsNullOrWhiteSpace(config.PageContactName))
                missingConfig.Add(nameof(config.PageContactName));

            if (string.IsNullOrWhiteSpace(config.AssembliesBasePath))
                missingConfig.Add(nameof(config.AssembliesBasePath));

            if (missingConfig.Any())
                throw new Exception(string.Format("Missing [{0}] from [SwaggerConfiguration].", string.Join(',', missingConfig)));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly SwaggerConfiguration swaggerConfiguration;
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="swaggerConfiguration"></param>
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider, SwaggerConfiguration swaggerConfiguration)
        {
            this.provider = provider;
            this.swaggerConfiguration = swaggerConfiguration;
        }

        /// <inheritdoc />
        public void Configure(SwaggerGenOptions options)
        {
            // add a swagger document for each discovered API version
            // note: you might choose to skip or document deprecated API versions differently
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }

        private OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = swaggerConfiguration.PageDisplayName,
                Version = description.ApiVersion.ToString(),
                Contact = new OpenApiContact
                {
                    Name = swaggerConfiguration.PageContactName,
                },
            };

            if (description.IsDeprecated)
                info.Description += "Esta API está depreciada.";

            return info;
        }
    }
}
