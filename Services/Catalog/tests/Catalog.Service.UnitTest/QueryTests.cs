using Catalog.Service.API;
using Catalog.Service.Application.Queries;
using Catalog.Service.Domain.Repositories;
using Catalog.Service.Persistence.Data;
using Catalog.Service.Persistence.Repositories;
using Catalog.Service.Persistence.Resolvers;
using Catalog.Service.Persistence.Types;

using HotChocolate;
using HotChocolate.Execution;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace Catalog.Service.UnitTest
{
    public class QueryTests
    {
        [Fact]
        public async Task Query_Return_ProductsAsync()
        {
            // Arrange
            IRequestExecutor executor =
                await new ServiceCollection()
                .AddSingleton(sp => new MongoDbSettings()) // Should be mocked
                .AddSingleton<ICatalogContext, CatalogContext>() // Should be mocked
                .AddScoped<ICategoryRepository, CategoryRepository>() // Should be mocked
                .AddScoped<IProductRepository, ProductRepository>() // Should be mocked
                .AddGraphQL()
                     .AddQueryType<Query>()                    // ✅ real root type
                    .AddTypeExtension<ProductQuery>()     // ✅ extension attaches to it
                    .AddType<ProductType>()
                    .AddTypeExtension<CategoryResolver>() // ✅ extension, not AddType
                .BuildRequestExecutorAsync();

            // Act
            IExecutionResult result = await executor.ExecuteAsync("{ products { description price } }");

            dynamic jsonObj = !JsonConvert.DeserializeObject<dynamic>(result.ToJson(false));

            // Assert
            Assert.Null(jsonObj.errors);
            Assert.NotNull(jsonObj.data);
            Assert.NotEmpty(jsonObj.data.products);
        }
    }
}
