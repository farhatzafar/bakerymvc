using System.Web;
using System.Web.Optimization;

namespace BakeryApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // jQuery bundle
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // jQuery validation bundle
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Modernizr for development (if you're using it)
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            // Bootstrap JavaScript bundle
            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            // Custom CSS bundle, including the Quartz theme and site.css
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-quartz.css", // Quartz theme
                      "~/Content/site.css"));           // custom site.css
        }
    }
}
