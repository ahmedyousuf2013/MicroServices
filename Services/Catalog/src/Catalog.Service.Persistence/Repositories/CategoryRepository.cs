using Catalog.Service.Domain.Entities;
using Catalog.Service.Domain.Repositories;
using Catalog.Service.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ICatalogContext catalogContext) : base(catalogContext)
        {
        }
    }
}
