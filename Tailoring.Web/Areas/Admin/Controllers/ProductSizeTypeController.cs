using System.Linq;
using System.Web.Mvc;
using Tailoring.Domain.Providers;
using Tailoring.Models;
using Tailoring.Web.Areas.Admin.Helpers;

namespace Tailoring.Web.Areas.Admin.Controllers {
    public class ProductSizeTypeController: Controller {
        private IHandler<Product> _productHandler;
        private IHandler<ProductSizeType> _productSizeHhandler;
        public ProductSizeTypeController(IHandler<ProductSizeType> productSizeHhandler, IHandler<Product> productHandler) {
            _productSizeHhandler = productSizeHhandler;
            _productHandler = productHandler;
        }
        // GET: Admin/ProductSizeType
        public ActionResult Index() {
            return View(_productSizeHhandler.GetAll());
        }

        // GET: Admin/ProductSizeType/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET: Admin/ProductSizeType/Create
        public ActionResult Create() {
            ViewBag.ProductList = _productHandler.GetAll().Select(x => new SelectListItem() { Text = x.Description, Value = x.Id.ToString() });
            return View();
        }

        // POST: Admin/ProductSizeType/Create
        [HttpPost]
        public ActionResult Create([ModelBinder(typeof(ProductSizeBinder))]ProductSizeType collection) {
            try {
                _productSizeHhandler.Insert(collection);
                // TODO: Add insert logic here .Select(x=> new SelectListItem() {Text=x.Description, Value=x.Id.ToString() })

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Admin/ProductSizeType/Edit/5
        public ActionResult Edit(int id) {
            return View();
        }

        // POST: Admin/ProductSizeType/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection) {
            try {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            } catch {
                return View();
            }
        }

        // GET: Admin/ProductSizeType/Delete/5
        public ActionResult Delete(int id) {
            return View();
        }

        // POST: Admin/ProductSizeType/Delete/5
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
