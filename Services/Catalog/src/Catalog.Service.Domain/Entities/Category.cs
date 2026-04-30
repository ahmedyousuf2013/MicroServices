using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Domain.Entities
{
    public class Category : BaseEntity
    {

        public string Description { get; set; }
    }
}
