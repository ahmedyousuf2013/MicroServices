using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalog.Service.Domain.Entities
{
    public class Product :BaseEntity
    {

        [BsonElement("Name")]
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
