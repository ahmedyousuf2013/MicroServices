using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Domain.Configurations
{
    public class MongoDbConfiguration
    {
        public string ConnectionString { get; set; }
        public string Database { get; set; }
    }
}
