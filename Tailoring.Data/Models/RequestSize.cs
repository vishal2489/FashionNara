namespace Tailoring.Data.Models {
    public class RequestSize {
        public int RequestOrderId { get; set; }
        public int ProductOptionsId { get; set; }
        public RequestOrder RequestOrder { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}
