using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Tailoring.Data.Models {
    public class Product {
        [BsonElement("_id")]
        public ObjectId _id { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } //product image url
        public bool IsAcive { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int FromAmout { get; set; }
        public int ToAmout { get; set; }
    }
}