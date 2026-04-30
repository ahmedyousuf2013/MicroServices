using Catalog.Service.Domain.Entities;
using Catalog.Service.Domain.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Application.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class ProductQuery
    {
        public async Task<IEnumerable<Product>> GetProductsAsync([Service] IProductRepository productRepository) 
            =>await productRepository.GetAllAsync();
      
    }
}
