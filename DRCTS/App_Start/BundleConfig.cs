using System.Web.Optimization;

namespace IdentitySample
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            bundles.Add(new ScriptBundle("~/bundles/startmin").Include(
                       "~/Scripts/morris.min.js",
                       "~/Scripts/morris-data.js",
                       "~/Scripts/startmin.js"));
            bundles.Add(new ScriptBundle("~/bundles/metis").Include(
                       "~/Scripts/metisMenu.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/startmin").Include(
                     "~/Content/startmin.css",
                     "~/Content/timeline.css",
                     "~/Content/morris.css"));

            bundles.Add(new StyleBundle("~/Content/Swatch").Include(
                     "~/Content/bootswatch/cerulean/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/Swatch-SP").Include(
                     "~/Content/bootswatch/cosmo/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/fontawesome").Include("~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/metis").Include("~/Content/metisMenu.min.css"));
            bundles.Add(new StyleBundle("~/Content/DataTables").Include(
                                          "~/Content/DataTables/jquery.dataTables.css"));
            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                     "~/Scripts/DataTables/jquery.dataTables.js"));

        }
    }
}
