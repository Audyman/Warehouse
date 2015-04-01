using System.Web.Mvc;
using Warehouse.ViewModel.Products;
using Warehouse.WebApp.AppCode;
using Warehouse.WebApp.AppCode.Base;

namespace Warehouse.WebApp.Controllers
{
    public class AdminController : BaseController
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
        public ActionResult AddGroup(ProductGroupViewModel model)
        {
            return RedirectToAction(NameHelper.Admin.Index, NameHelper.Admin.Controller);
        }
    }
}