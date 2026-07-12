using Catalog.Service.Domain.Entities;
using Catalog.Service.Domain.Repositories;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Application.Queries
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class CategoryQuery
    {
        public async Task<IEnumerable<Category>> GetCategoriesAsync(
            [Service] ICategoryRepository categoryRepository)
            => await categoryRepository.GetAllAsync();
    }
}
