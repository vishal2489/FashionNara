using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Bson;
using Tailoring.Models;
using Tailoring.Web.Helper;
using Tailoring.Web.Models;


namespace Tailoring.Web.Controllers {
    public class OrderController: Controller {

        private INavigation _navigation;
        private IUserSession _userSession;
        public OrderController(INavigation navigation, IUserSession userSession) {
            _navigation = navigation;
            _userSession = userSession;
        }

        // GET: Product
        public ActionResult Index(string productId) {
            ObjectId id = new ObjectId(productId);
            // Session["SelectedProduct"] = _navigation.Products.Find(x => x.Id == id);
            _userSession.SelectedProduct = _navigation.Products.Find(x => x.Id == id);
            _userSession.CurrentRequestOrder.Product = _navigation.Products.Find(x => x.Id == id);
            Session["userSession"] = _userSession;
            return View(_navigation.ProductOptions.Where(X => X.ProductId == id).ToList());
        }
        [HttpPost]
        public ActionResult Index([ModelBinder(typeof(SizeSelectionBinder))]List<ProductOption> collection) {
            _userSession = (IUserSession)Session["userSession"];
            // _userSession.CurrentRequestOrder.Product =  //_userSession.SelectedProduct;
            _userSession.CurrentRequestOrder.ProductOptions = collection;
            ////_userSession.CurrentRequestOrder.ProductOptions = collection.
            return RedirectToAction("Preview");
        }


        public ActionResult Preview() {
            return View();
        }


    }
}
