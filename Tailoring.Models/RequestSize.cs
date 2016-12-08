namespace Tailoring.Models {
    public class RequestSize: EntityBase {
        public int RequestOrderId { get; set; }
        public int ProductOptionsId { get; set; }
        public RequestOrder RequestOrder { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}
