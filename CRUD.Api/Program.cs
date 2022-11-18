using CRUD.Application;
using CRUD.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Cors.Infrastructure;
using CRUD.Application.Features.Users.Users.Commands.InsertUsers;
using Newtonsoft.Json;
using CRUD.Api.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.RegisterEF<Context>(builder.Configuration);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDocumentation(builder.Configuration);

builder.Services.AddMvc(options =>
{
    options.ModelMetadataDetailsProviders.Add(new BindingSourceMetadataProvider(typeof(InsertUserCommandHandler), BindingSource.ModelBinding));
    options.EnableEndpointRouting = false;
    options.RespectBrowserAcceptHeader = true;
    options.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson(options =>
{
    options.SerializerSettings.Formatting = Formatting.None;
    options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Populate;
    options.UseCamelCasing(true);
    options.UseMemberCasing();
})
.AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwaggerDocumentation();
}

app.UseCors(delegate (CorsPolicyBuilder policyBuilder) {
    policyBuilder.SetIsOriginAllowed((o) => true)
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials();
});

app.UseHttpsRedirection();

app.UseAuthorization();

await app.Services.MigrateDatabaseAsync<Context>();

app.MapControllers();

app.Run();
