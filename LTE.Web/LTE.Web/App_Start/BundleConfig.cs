using System.Web;
using System.Web.Optimization;

namespace LTE.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js",
            //          "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/plugins/bootstrap/bootstrap.min.js",
                "~/Content/js/app.js",
                "~/Content/js/demo.js",
                "~/Scripts/respond.js"
            ));


            //
            //          < !--InputMask-- >
            //< script src = "../../plugins/input-mask/jquery.inputmask.js" ></ script >
            //< script src = "../../plugins/input-mask/jquery.inputmask.date.extensions.js" ></ script >
            //< script src = "../../plugins/input-mask/jquery.inputmask.extensions.js" ></ script >
            bundles.Add(new ScriptBundle("~/bundles/plugin").Include(
                  "~/Scripts/plugins/slimScroll/jquery.slimscroll.min.js",
                  "~/Scripts/plugins/fastclick/fastclick.js",
                  "~/Scripts/plugins/iCheck/icheck.js",
                  "~/Scripts/plugins/input-mask/jquery.inputmask.js",
                  "~/Scripts/plugins/input-mask/jquery.inputmask.date.extensions.js",
                  "~/Scripts/plugins/input-mask/jquery.inputmask.extensions.js"
            ));

            // CSS
            bundles.Add(new StyleBundle("~/Content/css").Include(
                    "~/Scripts/plugins/bootstrap/bootstrap.min.css",
                  
                    "~/Content/Site.css",
                    "~/Scripts/plugins/iCheck/square/blue.css",
                     "~/Scripts/plugins/select2/select2.min.css",
                       "~/Content/css/AdminLTE.css"
            ));

            // Skin css
            bundles.Add(new StyleBundle("~/Content/skin").Include(
                "~/Content/css/skins/_all-skins.min.css"
                ));
        }
    }
}
