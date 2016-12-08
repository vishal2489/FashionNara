using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MongoDB.Bson;
using Tailoring.Models;
using Tailoring.Web.Helper;
using Tailoring.Web.Models;


namespace Tailoring.Web.Controllers {
    public class SizeSelectionController: Controller {

        private INavigation _navigation;
        private IUserSession _userSession;
        public SizeSelectionController(INavigation navigation, IUserSession userSession) {
            _navigation = navigation;
            _userSession = userSession;
        }

        // GET: Product
        public ActionResult Index(string productId) {
            ObjectId id = new ObjectId(productId);
            _userSession.SelectedProduct = _navigation.Products.Find(x => x.Id == id);
            return View(_navigation.ProductOptions.Where(X => X.ProductId == id).ToList());
        }
        [HttpPost]
        public ActionResult Index([ModelBinder(typeof(SizeSelectionBinder))]List<ProductOption> collection) {
            _userSession.CurrentRequestOrder.Product = _userSession.SelectedProduct;
            _userSession.CurrentRequestOrder.ProductOptions = collection;
            //_userSession.CurrentRequestOrder.ProductOptions = collection.
            return View();
        }

        // GET: Product/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create() {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection) {
            try {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection) {
            try {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }
    }
}
