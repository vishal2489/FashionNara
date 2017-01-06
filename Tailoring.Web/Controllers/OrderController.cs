using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Bson;
using Tailoring.Domain.Providers;
using Tailoring.Models;
using Tailoring.Web.Helper;
using Tailoring.Web.Models;


namespace Tailoring.Web.Controllers {
    public class OrderController: Controller {

        private INavigation _navigation;
        private IUserSession _userSession;
        private IHandler<RequestOrder> _orderHandler;
        public OrderController(INavigation navigation, IUserSession userSession, IHandler<RequestOrder> orderHandler) {
            _navigation = navigation;
            _userSession = userSession;
            _orderHandler = orderHandler;
        }

        // GET: Product
        public ActionResult Index(string productId) {
            ObjectId id = new ObjectId(productId);
            // Session["SelectedProduct"] = _navigation.Products.Find(x => x.Id == id);
            _userSession.SelectedProduct = _navigation.Products.Find(x => x.Id == id);
            var product = _navigation.Products.Find(x => x.Id == id);
            var lastOder = _orderHandler.GetAll().OrderByDescending(x => x.OrderNumber).FirstOrDefault();
            _userSession.CurrentRequestOrder.Product = product;
            _userSession.CurrentRequestOrder.BaseAmount = product.FromAmout;
            _userSession.CurrentRequestOrder.OrderNumber = lastOder != null ? lastOder.OrderNumber + 1 : 1;
            Session["userSession"] = _userSession;
            var productOptions = _navigation.ProductOptions.Where(X => X.ProductId == id).ToList();
            Session["navigation"] = _navigation;
            return View(_navigation.ProductOptions.Where(X => X.ProductId == id).ToList());
        }
        [HttpPost]
        public ActionResult Index([ModelBinder(typeof(SizeSelectionBinder))]List<ProductOption> collection) {
            _userSession = (IUserSession)Session["userSession"];
            // _userSession.CurrentRequestOrder.Product =  //_userSession.SelectedProduct;
            _userSession.CurrentRequestOrder.ProductOptions = collection;
            _userSession.CurrentRequestOrder.AddOnAmount = collection.Where(x => x.OptionType.ToLower().Equals("add-ons")).Sum(x => x.Amount);
            Session["userSession"] = _userSession;
            ////_userSession.CurrentRequestOrder.ProductOptions = collection.
            return RedirectToAction("Preview");
        }


        public ActionResult Preview() {
            _userSession = (IUserSession)Session["userSession"];
            _userSession.CurrentRequestOrder.TotalAmount = _userSession.CurrentRequestOrder.AddOnAmount + _userSession.CurrentRequestOrder.BaseAmount;
            return View(_userSession.CurrentRequestOrder);
        }


    }
}
