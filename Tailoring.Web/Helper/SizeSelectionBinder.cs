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
                            userlist[newListIndex].ProductOptions[newOptionIndex].IsSelected = isSelectedOption;
                            var option = userlist[newListIndex].ProductOptions.Find(x => x.Id.Equals(userlist[newListIndex].ProductOptions[newOptionIndex].Id));
                            userProductOption.Add(option);
                            userlist[newListIndex].ProductOptions = new List<ProductOption>();
                            userlist[newListIndex].ProductOptions.Add(option);
                        }
                    }
                }
            }
            //for (int i = 0; i < request.Form.Count; i++) {
            //    var key = request.Form.AllKeys[i];
            //    var keyArrary = key.Split('.');
            //    int.TryParse(keyArrary[0].ToArray()[1].ToString(), out newListIndex);
            //    if (keyArrary.Count() == 2) {
            //        if (userlist.Count == 0) {
            //            userlist.Add(new UserSizeSlection());
            //        } else if (newListIndex != userlist.Count - 1) {
            //            userlist.Add(new UserSizeSlection());
            //        }
            //        if (keyArrary[1].ToLower() == "id") {
            //            userlist[newListIndex].Id = new ObjectId(request.Form.Get(key));
            //        } else if (keyArrary[1].ToLower() == "productid") {
            //            userlist[newListIndex].ProductId = new ObjectId(request.Form.Get(key));
            //        } else if (keyArrary[1].ToLower() == "sortorder") {
            //            int sortOrder;
            //            int.TryParse(request.Form.Get(key), out sortOrder);
            //            userlist[newListIndex].SortOrder = sortOrder;

            //        }
            //    } else {
            //        int.TryParse((keyArrary[1].Substring(keyArrary[1].Count() - 3).ToArray())[1].ToString(), out newOptionIndex);
            //        if (newOptionIndex != userlist[newListIndex].ProductOptions.Count - 1) {
            //            userlist[newListIndex].ProductOptions.Add(new ProductOption());
            //        }
            //        if (keyArrary[2].ToLower() == "id") {
            //            userlist[newListIndex].ProductOptions[newOptionIndex].Id = new ObjectId(request.Form.Get(key));
            //        } else if (keyArrary[2].ToLower() == "isselected") {
            //            userlist[newListIndex].ProductOptions[newOptionIndex].IsSelected = (bool)bindingContext.ValueProvider.GetValue(key).ConvertTo(typeof(bool));
            //            if (userlist[newListIndex].ProductOptions[newOptionIndex].IsSelected) {
            //                userProductOption.Add(userlist[newListIndex].ProductOptions[newOptionIndex]);
            //            }
            //        }
            //    }
            //}


            //return userlist;
            return userProductOption;
        }
    }
}