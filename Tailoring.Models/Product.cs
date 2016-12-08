
namespace Tailoring.Models {
    public class Product: EntityBase {

        public string Description { get; set; }
        public string ImageUrl { get; set; } //product image url
        public bool IsAcive { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public int FromAmout { get; set; }
        public int ToAmout { get; set; }
    }
}