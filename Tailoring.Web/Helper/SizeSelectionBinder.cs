using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoDB.Bson;
using Tailoring.Models;
using Tailoring.Web.Models;

namespace Tailoring.Web.Helper {
    public class SizeSelectionBinder: IModelBinder {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            var userProductOption = new List<ProductOption>();
            var userlist = new List<UserSizeSlection>();
            var navigations = (INavigation)controllerContext.HttpContext.Session["navigation"];
            int newListIndex, newOptionIndex = 0;
            for (int i = 0; i < request.Form.Count; i++) {
                var key = request.Form.AllKeys[i];
                var keyArrary = key.Split('.');
                int.TryParse(keyArrary[0].ToArray()[1].ToString(), out newListIndex);
                if (keyArrary.Count() == 2) {
                    if (userlist.Count == 0) {
                        userlist.Add(new UserSizeSlection());
                    } else if (newListIndex != userlist.Count - 1) {
                        userlist.Add(new UserSizeSlection());
                    }
                    if (keyArrary[1].ToLower() == "id") {
                        var id = new ObjectId(request.Form.Get(key));
                        userlist[newListIndex] = navigations.ProductOptions.Find(x => x.Id.Equals(id));
                    }

                } else {
                    int.TryParse((keyArrary[1].Substring(keyArrary[1].Count() - 3).ToArray())[1].ToString(), out newOptionIndex);
                    if (keyArrary[2].ToLower() == "isselected") {
                        var isSelectedOption = (bool)bindingContext.ValueProvider.GetValue(key).ConvertTo(typeof(bool));
                        if (isSelectedOption) {
                            var option = userlist[newListIndex].ProductOptions.Find(x => x.Id.Equals(userlist[newListIndex].ProductOptions[newOptionIndex].Id));
                            userProductOption.Add(new ProductOption() {
                                Amount = option.Amount,
                                Description = option.Description,
                                Group = option.Group,
                                Id = option.Id,
                                ImageUrl = option.ImageUrl,
                                IsActive = option.IsActive,
                                IsDefaultWithProduct = option.IsDefaultWithProduct,
                                IsFree = option.IsFree,
                                IsSelected = true,
                                OptionType = userlist[newListIndex].Description,
                                ProductSizeTypeId = option.ProductSizeTypeId
                            });
                        }
                    }
                }
            }
            return userProductOption;
        }
    }
}