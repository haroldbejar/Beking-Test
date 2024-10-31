﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
namespace ProductManagementApp.Domain.Entities
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } 
        public string Category { get; set; } = string.Empty;
    }
}