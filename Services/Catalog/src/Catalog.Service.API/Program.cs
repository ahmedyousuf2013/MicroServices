using Catalog.Service.API;
using Catalog.Service.Application.Queries;
using Catalog.Service.Domain.Repositories;
using Catalog.Service.Persistence.Data;
using Catalog.Service.Persistence.Repositories;
using HotChocolate.Execution.Processing;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Collections;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

builder.Services.AddMongoDb(builder.Configuration);

// Repositories
builder.Services.AddSingleton<ICatalogContext, CatalogContext>();
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.AllowSynchronousIO = true;
});


builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    .AddInMemorySubscriptions()
    .AddQueryType(d => d.Name("Query"))
        .AddTypeExtension<ProductQuery>() // define your root Query
    //.AddMutationType<Mutation>()    // define your root Mutation
    //.AddSubscriptionType<Subscription>() // define your root Subscription
    // .AdddQueryExtensionType()
    // .AdddMutationExtensionType()
    //.AddSubscrintionType()
    .AddFiltering()
    .AddSorting()
    .AddProjections()
    .AddPagingArguments();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{

//}

//app.MapDefaultEndpoints();

//app.MapDefaultEndpoints();
app.UseWebSockets();
app.MapGraphQL("/api/graphql");
// Middleware pipeline
app.UseRouting();

//app.UseOutputCache();

//if (app.Environment.IsDevelopment()) {


//}



app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();



// HotChocolate GraphQL endpoint

// REST Controllers
app.MapControllers();

using var scope = app.Services.CreateScope();
var mongoDatabase = scope.ServiceProvider.GetRequiredService<IMongoDatabase>();

CatalogContextSeed.SeedData(mongoDatabase);

app.Run();
