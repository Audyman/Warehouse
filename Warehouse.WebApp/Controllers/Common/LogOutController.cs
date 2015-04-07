using System.Web.Mvc;
using System.Web.Routing;
using Warehouse.WebApp.AppCode;
using Warehouse.WebApp.AppCode.Base;
using WebMatrix.WebData;

namespace Warehouse.WebApp.Controllers.Common
{
    public class LogOutController : BaseController
    {
        public ActionResult Index()
        {
            return LogoutUser();
        }

        public RedirectToRouteResult LogoutUser()
        {
            WebSecurity.Logout();
            return new RedirectToRouteResult(new RouteValueDictionary(new
            {
                action = NameHelper.Home.Index,
                controller = NameHelper.Home.Controller
            }));
        }
    }
}