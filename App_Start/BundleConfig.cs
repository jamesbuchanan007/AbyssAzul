using System.Web;
using System.Web.Optimization;

namespace AbyssAzul
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Content/html/vendor"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/Content/html/vendor/bootstrap"));

            bundles.Add(new StyleBundle("~/Content/html/css").Include(
                      "~/Content/html/vendor/bootstrap/css"));
        }
    }
}
