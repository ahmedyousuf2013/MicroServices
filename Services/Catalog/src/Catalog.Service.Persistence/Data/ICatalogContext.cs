using Catalog.Service.Domain.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Persistence.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }

}
