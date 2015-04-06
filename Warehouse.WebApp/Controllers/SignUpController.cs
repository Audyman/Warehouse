using System.Web.Mvc;
using Warehouse.ViewModel.Users;
using Warehouse.WebApp.AppCode;

namespace Warehouse.WebApp.Controllers
{
    public class SignUpController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateNewUser(SignUpViewModel model)
        {
            return RedirectToAction(NameHelper.Home.Index, NameHelper.Home.Controller);
        }
    }
}