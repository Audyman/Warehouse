using System.Web;
using System.Web.Optimization;

namespace Warehouse.WebApp
{
    public class BundleConfig
    {
        public const string JqueryScripts = "~/bundles/jquery";
        public const string JqueryValScripts = "~/bundles/jqueryval";
        public const string BootstrapScripts = "~/bundles/bootstrap";
        public const string KnockoutScripts = "~/bundles/knockout";
        public const string TeamPageScripts = "~/bundles/knockoutProductModels";

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle(JqueryScripts).Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle(JqueryValScripts).Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle(KnockoutScripts).Include(
                "~/Scripts/knockout-3.2.0.debug.js"));

            bundles.Add(new ScriptBundle(TeamPageScripts).Include(
                "~/Scripts/ProductsModel.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle(BootstrapScripts).Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
