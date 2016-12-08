using MongoDB.Bson;

namespace Tailoring.Models {
    public class ProductOption: EntityBase {

        public ObjectId ProductSizeTypeId { get; set; }
        public string OptionType { get; set; } //like Front, Back...
        public int Amount { get; set; }
        public string Group { get; set; } //to match with front and back design sinc
        public bool IsDefaultWithProduct { get; set; }
        public bool IsFree { get; set; }
        public bool IsSelected { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; } //SVC URL
        public bool IsActive { get; set; }
    }
}