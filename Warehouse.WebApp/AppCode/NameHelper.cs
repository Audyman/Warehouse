using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using Warehouse.WebApp.Controllers;

namespace Warehouse.WebApp.AppCode
{
    public class NameHelper
    {
        #region Home

        public static class Home
        {
            public static string Controller
            {
                get { return GetController<HomeController>(); }
            }

            public static string Index
            {
                get { return GetAction<HomeController>(e => e.Index()); }
            }

            public static string Login
            {
                get { return GetAction<HomeController>(e => e.Login(null)); }
            }

            public static string SetCulture
            {
                get { return GetAction<HomeController>(e => e.SetCulture(default(string))); }
            }
        }

        #endregion

        #region Catalog

        public static class Catalog
        {
            public static string Controller
            {
                get { return GetController<CatalogController>(); }
            }

            public static string ViewCatalog
            {
                get { return GetAction<CatalogController>(e => e.ViewCatalog()); }
            }

            public static string GetCatalog
            {
                get { return GetAction<CatalogController>(e => e.GetCatalog()); }
            }
        }

        #endregion

        #region Admin

        public static class Admin
        {
            public static string Controller
            {
                get { return GetController<AdminController>(); }
            }

            public static string Index
            {
                get { return GetAction<AdminController>(e => e.Index()); }
            }

            public static string AddItems
            {
                get { return GetAction<AdminController>(e => e.AddItems()); }
            }

            public static string AddGroup
            {
                get { return GetAction<AdminController>(e => e.AddGroup(null)); }
            }
        }

        #endregion

        #region SignUp

        public static class SignUp
        {
            public static string Controller
            {
                get { return GetController<SignUpController>(); }
            }

            public static string Index
            {
                get { return GetAction<SignUpController>(e => e.Index()); }
            }

            public static string CreateNewUser
            {
                get { return GetAction<SignUpController>(e => e.CreateNewUser(null)); }
            }
        }

        #endregion

        #region Private Methods

        private static string GetAction<TController>(Expression<Func<TController, object>> action)
            where TController : Controller
        {
            if (action == null) throw new ArgumentNullException("action");

            var methodExpression = (action.Body as MethodCallExpression);
            if (methodExpression == null) throw new ArgumentException("method expression");

            return methodExpression.Method.Name;
        }


        private static string GetController<TController>()
            where TController : IController
        {
            return GetController(typeof(TController));
        }

        public static string GetController(Type controller)
        {
            return controller.Name.Replace("Controller", string.Empty);
        }

        #endregion
    }
}