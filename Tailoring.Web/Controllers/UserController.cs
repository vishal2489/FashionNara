using System.Web.Mvc;
using Tailoring.Domain.Providers;
using Tailoring.Models;
using Tailoring.Web.Models;

namespace Tailoring.Web.Controllers
{
    public class UserController : Controller
    {
        private IHandler<User> _userHandler;
        private IUserSession _userSession;
        public UserController(IHandler<User> userHandler, IUserSession userSession) {
            _userHandler = userHandler;
            _userSession = userSession;
        }
        public ActionResult SignUp() {
            return View();
        }
        [HttpPost]
        public ActionResult SignUp(User user) {
            _userHandler.Insert(user);
            return RedirectToAction("Preview", "Order");
        }
    }
}
