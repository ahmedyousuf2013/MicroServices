using Catalog.Service.Domain.Entities;
using Catalog.Service.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Persistence.Resolvers
{
    [ExtendObjectType(Name = "Category")]
    public class CategoryResolver
    {
        public Task<Category> GetCategoryAsync([Parent] Product product, [Service] ICategoryRepository categoryRepository) =>
            categoryRepository.GetByIdAsync(product.CategoryId);
    }
}
