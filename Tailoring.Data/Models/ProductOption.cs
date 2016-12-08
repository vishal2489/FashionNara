using MongoDB.Bson.Serialization.Attributes;

namespace Tailoring.Data.Models {
    public class ProductOption {
        [BsonId]
        public object _id { get; set; }
        public int OptionTypeId { get; set; }
        public int Amount { get; set; }
        public string Group { get; set; } //to match with front and back design sinc
        public bool IsDefaultWithProduct { get; set; }
        public bool IsFree { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } //SVC URL
        public bool IsActive { get; set; }
    }
}