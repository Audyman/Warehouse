using System.Web.Mvc;
using Warehouse.WebApp.AppCode;

namespace Warehouse.WebApp.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddItems()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddItems(int? id)
        {
            return RedirectToAction(NameHelper.Admin.Index, NameHelper.Admin.Controller);
        }
    }
}