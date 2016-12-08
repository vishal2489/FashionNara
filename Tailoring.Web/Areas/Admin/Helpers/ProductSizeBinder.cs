using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using Tailoring.Models;

namespace Tailoring.Web.Areas.Admin.Helpers {
    public class ProductSizeBinder: IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            string description = request.Form.Get("Description");
            string sortOrder = request.Form.Get("SortOrder");
            string productId = request.Form.Get("ProductId");


            return new ProductSizeType {
                Description = description,
                ProductId = new ObjectId(productId),
                SortOrder = int.Parse(sortOrder)

            };
        }
    }
}