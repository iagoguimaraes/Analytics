using System.Web;
using System.Web.Optimization;

namespace Analytics.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            string[] coreScripts = {
                "~/Content/Scripts/jquery.min.js",
                "~/Content/Scripts/bootstrap.min.js",
                "~/Content/Scripts/angular.min.js",
                "~/Content/Scripts/adminlte.js",
                "~/Content/Scripts/loading.js",
            };

            string[] coreStyles = {
                "~/Content/Styles/bootstrap.min.css",
                "~/Content/Styles/font-awesome.min.css",
                "~/Content/Styles/google-fonts.css",
                "~/Content/Styles/ionicons.min.css",
                "~/Content/Styles/loading.css",
                "~/Content/Styles/adminlte.css",
                "~/Content/Styles/skin-black.min.css",
            };

            string[] dashScripts =
            {
                "~/Content/Scripts/highcharts.js",              
                "~/Content/Scripts/jquery.dataTables.min.js",
                "~/Content/Scripts/dataTables.bootstrap.min.js",
                "~/Content/Scripts/bootstrap-datepicker.min.js",
                "~/Content/Scripts/select2.full.min.js",
            };

            string[] dashStyles =
            {
                "~/Content/Styles/datatables.min.css",
                "~/Content/Styles/dataTables.bootstrap.min.css",
                "~/Content/Styles/bootstrap-datepicker.min.css",               
                "~/Content/Styles/select2.min.css",
            };
 
            bundles.Add(new ScriptBundle("~/coreScripts").Include(coreScripts));
            bundles.Add(new StyleBundle("~/coreStyles").Include(coreStyles));

            bundles.Add(new ScriptBundle("~/dashboardScripts").Include(dashScripts));
            bundles.Add(new StyleBundle("~/dashboardStyles").Include(dashStyles));
        }
    }
}