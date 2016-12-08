using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Tailoring.Web.Areas.Admin.Helpers;

namespace Tailoring.Web {
    public class MvcApplication: System.Web.HttpApplication {
        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ModelBinders.Binders.Add(typeof(ProductSizeBinder), new ProductSizeBinder());
            ModelBinders.Binders.Add(typeof(ProductOptionBinder), new ProductOptionBinder());
        }
    }
}
