using Tailoring.Models;

namespace Tailoring.Web.Models {
    public class UserSession: IUserSession {
        public UserSession() {
            this.SelectedProduct = new Product();
            this.CurrentRequestOrder = new RequestOrder();
        }
        public Product SelectedProduct { get; set; }
        public RequestOrder CurrentRequestOrder { get; set; }
    }
    public interface IUserSession {
        Product SelectedProduct { get; set; }
        RequestOrder CurrentRequestOrder { get; set; }
    }
}