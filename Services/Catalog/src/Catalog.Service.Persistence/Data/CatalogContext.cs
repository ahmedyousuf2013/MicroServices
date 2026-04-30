using Catalog.Service.Domain.Configurations;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Persistence.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly IMongoDatabase database;

        public CatalogContext(IMongoDatabase database)
        {
            this.database = database;
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return this.database.GetCollection<T>(name);
        }
    }
}
