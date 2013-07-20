using System.Web.Mvc;
using PrivateZone.Web.BL.Security;
using PrivateZone.Web.Models;

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

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Register");
            }

            this.securityService.Register(registerModel.NickName, registerModel.Password);
            return RedirectToAction("Login");
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

        [HttpPost]
        public ActionResult Login(LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Login");
            }

            ViewBag.IsLogin = this.securityService.Login(loginModel.UserName, loginModel.Password);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            this.securityService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
