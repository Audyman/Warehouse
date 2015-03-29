using System;
using System.Web;
using System.Web.Mvc;
using Warehouse.ViewModel.Users;
using Warehouse.WebApp.AppCode;
using Warehouse.WebApp.AppCode.Base;

namespace Warehouse.WebApp.Controllers
{
    [AllowAnonymous]
    public class HomeController : BaseController
    {
        private const string CookieName = "_culture";

        public HomeController() { }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model)
        {
            return Login(model);
        }

        public ActionResult Login(LoginViewModel model)
        {
            return RedirectToAction(NameHelper.Catalog.ViewCatalog, NameHelper.Catalog.Controller);
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