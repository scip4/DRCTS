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
                      // "~/Scripts/morris.min.js",
                      // "~/Scripts/morris-data.js",
                       "~/Scripts/startmin.js"));
            bundles.Add(new ScriptBundle("~/bundles/metis").Include(
                       "~/Scripts/metisMenu.js"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/moment.js",
                      "~/Scripts/xlsx.core.min.js",
                      "~/Scripts/FileSaver.min.js",
                      "~/Scripts/tableexport.js",
                      "~/Scripts/jquery.tabletojson.js",
                       "~/Scripts/jquery-ui-1.12.1.js",
                       "~/Scripts/jquery.easy-autocomplete.js",
                      "~/Scripts/bootstrap-datetimepicker.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/tableexport.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/bootstrap-datetimepicker.css"));
            bundles.Add(new StyleBundle("~/Content/startmin").Include(
                     "~/Content/startmin.css",
                     "~/Content/timeline.css"
                     ));

            bundles.Add(new StyleBundle("~/Content/Swatch").Include(
                     "~/Content/bootswatch/cerulean/bootstrap.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/Swatch-SP").Include(
                     "~/Content/bootswatch/cosmo/bootstrap.css",
                     "~/Content/themes/base/jquery-ui.css",
                      "~/Content/easy-autocomplete.css",
                      "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/fontawesome").Include("~/Content/font-awesome.css"));
            bundles.Add(new StyleBundle("~/Content/metis").Include("~/Content/metisMenu.min.css"));
            bundles.Add(new StyleBundle("~/Content/DataTables").Include(
                                          "~/Content/DataTables/jquery.dataTables.css"));
            bundles.Add(new ScriptBundle("~/bundles/DataTables").Include(
                     "~/Scripts/DataTables/jquery.dataTables.js"));


            bundles.Add(new StyleBundle("~/Content/calendar").Include(
                     "~/Content/bootstrap-datetimepicker.css"));
            bundles.Add(new ScriptBundle("~/bundles/calendar").Include(
                     "~/Scripts/bootstrap-datetimepicker.js",
                     "~/Scripts/moment.js"));
            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
            //~/Scripts/Inputmask/dependencyLibs/inputmask.dependencyLib.js",  //if not using jquery
 
"~/Scripts/Inputmask/inputmask.js",
            "~/Scripts/Inputmask/jquery.inputmask.js",
            "~/Scripts/Inputmask/inputmask.extensions.js",
           "~/Scripts/Inputmask/inputmask.date.extensions.min.js",
             "~/Scripts/Inputmask/inputmask.phone.extensions.js",
            
            //and other extensions you want to include
            "~/Scripts/Inputmask/inputmask.numeric.extensions.js"
           ));
        }
    }
}
