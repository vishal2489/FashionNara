using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using Tailoring.Models;

namespace Tailoring.Web.Areas.Admin.Helpers {
    public class ProductOptionBinder: IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {

            HttpRequestBase request = controllerContext.HttpContext.Request;

            // return new ProductOption {
            var amount = int.Parse(request.Form.Get("Amount"));
            var description = request.Form.Get("Description");
            var group = request.Form.Get("Group");
            var imageUrl = request.Form.Get("ImageUrl");
            bool isActive = (bool)bindingContext.ValueProvider.GetValue("IsActive").ConvertTo(typeof(bool));
            var isDefaultWithProduct = (bool)bindingContext.ValueProvider.GetValue("IsDefaultWithProduct").ConvertTo(typeof(bool));
            var isFree = (bool)bindingContext.ValueProvider.GetValue("IsFree").ConvertTo(typeof(bool));
            var productSizeTypeId = new ObjectId(request.Form.Get("ProductSizeTypeId"));

            return new ProductOption() {
                Description = description,
                Amount = amount,
                Group = group,
                ImageUrl = imageUrl,
                IsActive = isActive,
                IsDefaultWithProduct = isDefaultWithProduct,
                IsFree = isFree,
                ProductSizeTypeId = productSizeTypeId
            };
            //};
        }
    }
}