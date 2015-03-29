using System.Web.Mvc;
using Warehouse.Logic.Services.Products;
using Warehouse.WebApp.AppCode.Base;

namespace Warehouse.WebApp.Controllers
{
    public class CatalogController : BaseController
    {
        private readonly IProductService _productService;

        public CatalogController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult ViewCatalog()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCatalog()
        {
            var result = _productService.GetAllProducts();

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}