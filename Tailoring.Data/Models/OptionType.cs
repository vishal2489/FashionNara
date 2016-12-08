using MongoDB.Bson.Serialization.Attributes;

namespace Tailoring.Data.Models {
    public class ProductSizeType {// like Front, Back,.... Addon
        [BsonId]
        public object _id { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
        public int SortOrder { get; set; }
    }
}
