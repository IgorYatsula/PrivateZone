using System.Web.Mvc;
using PrivateZone.Web.BL;

namespace PrivateZone.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebSecurity securityService;

        public HomeController()
        {
            this.securityService = new SecurityService();
        }

        public ActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public ActionResult Login()
        {
            if (this.securityService.Login("me", "MyPass"))
            {
                ViewBag.LoginResult = "success";
            }
            ViewBag.LoginResult = "error";
            return View();
        }

        //
        // POST: /Account/LogOff

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            this.securityService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
