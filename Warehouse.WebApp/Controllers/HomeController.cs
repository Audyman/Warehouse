using System;
using System.Web;
using System.Web.Mvc;
using Warehouse.Providers.Security;
using Warehouse.ViewModel.Users;
using Warehouse.WebApp.AppCode;
using Warehouse.WebApp.AppCode.Base;

namespace Warehouse.WebApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private const string CookieName = "_culture";
        private const string ModelStateInvalidUserDataKey = "InvalidUserDataError";

        public HomeController() { }

        [HttpGet]
        public ActionResult Index()
        {
            if (User == null || User.Identity == null || string.IsNullOrWhiteSpace(User.Identity.Name) ||
                !MySqlWebSecurity.UserExists(User.Identity.Name)) return View();

            if (MySqlWebSecurity.IsAuthenticated)
            {
                return RedirectToAction(NameHelper.Catalog.ViewCatalog, NameHelper.Catalog.Controller);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            return ModelState.IsValid ? Login(model) : View(NameHelper.Home.Index, model);
        }

        public ActionResult Login(LoginViewModel model)
        {
            model.Login = model.Login.Trim();

            if (MySqlWebSecurity.Login(model.Login, model.Password, model.RememberMe))
            {
                return RedirectToAction(NameHelper.Catalog.ViewCatalog, NameHelper.Catalog.Controller);
            }

            ModelState.AddModelError(ModelStateInvalidUserDataKey, Resources.Resources.ModelStateInvalidUserDataKey);

            return View(NameHelper.Home.Index, model);
        }

        public ActionResult SetCulture(string culture)
        {
            culture = CultureHelper.GetImplementedCulture(culture);
            var cookie = Request.Cookies[CookieName];

            if (cookie != null)
                cookie.Value = culture;
            else
            {
                cookie = new HttpCookie(CookieName)
                {
                    Value = culture,
                    Expires = DateTime.Now.AddYears(1)
                };
            }

            Response.Cookies.Add(cookie);

            return RedirectToAction(NameHelper.Home.Index);
        }
    }
}