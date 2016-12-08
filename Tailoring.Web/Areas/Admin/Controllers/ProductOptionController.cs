using System.Linq;
using System.Web.Mvc;
using MongoDB.Bson;
using Tailoring.Domain.Providers;
using Tailoring.Models;
using Tailoring.Web.Areas.Admin.Helpers;

namespace Tailoring.Web.Areas.Admin.Controllers {
    public class ProductOptionController: Controller {

        private IHandler<ProductSizeType> _productSizeHandler;
        private IHandler<Product> _productHandler;
        private IHandler<ProductOption> _productOptionHandler;
        public ProductOptionController(IHandler<ProductSizeType> productSizeHandler, IHandler<ProductOption> productOptionHandler, IHandler<Product> productHandler) {
            _productHandler = productHandler;
            _productOptionHandler = productOptionHandler;
            _productSizeHandler = productSizeHandler;


        }
        // GET: Admin/ProductOption
        public ActionResult Index() {
            return View(_productOptionHandler.GetAll());
        }

        // GET: Admin/ProductOption/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Admin/ProductOption/Create
        public ActionResult Create() {
            ViewBag.ProductList = _productHandler.GetAll().Select(x => new SelectListItem() { Text = x.Description, Value = x.Id.ToString() });

            return View();
        }

        public ActionResult GetProductSizeTypeList(string productId) {
            ObjectId product = new ObjectId(productId);
            var productSizeTypeList = _productSizeHandler.GetAll().Where(x => x.ProductId == product).OrderBy(o => o.SortOrder).Select(x => new SelectListItem() { Text = x.Description, Value = x.Id.ToString() });
            return Json(productSizeTypeList, JsonRequestBehavior.AllowGet);
        }

        // POST: Admin/ProductOption/Create
        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(ProductOptionBinder))] ProductOption entity) {
            try {
                // TODO: Add insert logic here
                _productOptionHandler.Insert(entity);

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Admin/ProductOption/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Admin/ProductOption/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Admin/ProductOption/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Admin/ProductOption/Delete/5
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
