using System.Web.Mvc;
using Tailoring.Web.Models;

namespace Tailoring.Web.Controllers {
    public class HomeController: Controller {
        private INavigation _navigation;
        private IUserSession _userSession;
        public HomeController(INavigation navigation, IUserSession userSession) {
            _navigation = navigation;
            _userSession = userSession;
        }

        public ActionResult Index() {
            _userSession.CurrentRequestOrder = new Tailoring.Models.RequestOrder();
            return View(_navigation.Products);
        }


    }
}