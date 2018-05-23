using System.Web;
using System.Web.Optimization;

namespace CYT.Web
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

            bundles.Add(new ScriptBundle("~/bundles/angular/library").Include(
                     "~/Scripts/angular.js",
                     "~/Scripts/angular-file-upload.min.js",
                     "~/Scripts/angular-img-cropper.js",
                     "~/Scripts/angular-sanitize.js",
                     "~/Scripts/angular-resource.js",
                     "~/Scripts/angular-route.js",
                     "~/Scripts/angular-signalr-hub.js",
                     "~/Scripts/angular-animate.js",
                     "~/Scripts/angular-touch.js",
                     "~/Scripts/ckeditor/ckeditor.js",
                     "~/Scripts/angular-ckeditor/angular-ckeditor.js",
                     "~/Scripts/lodash.js",
                     "~/Scripts/angular-google-maps.js",
                     "~/Scripts/bower_components/angular-ui-router/release/angular-ui-router.js",
                     "~/Scripts/bower_components/angular-bootstrap/ui-bootstrap-tpls.js",
                     "~/Scripts/bower_components/angular-bootstrap-lightbox/dist/angular-bootstrap-lightbox.js",
                     "~/Scripts/bower_components/angular-ellipsis/src/angular-ellipsis.js"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/angular/app").Include(

                        "~/App/App.js",
                        "~/App/Core/*.module.js",
                        "~/App/Core/config.js",

                        /// DataServices
                        "~/App/DataServices/app.data.module.js",
                        "~/App/DataServices/*.data.js",
                        
                        /// Main
                        "~/App/Main/*.module.js",
                        "~/App/Main/*.controller.js",

                        /// Filter
                        "~/App/SearchRecipes/*.module.js",
                        "~/App/SearchRecipes/*.controller.js",

                        /// User
                        "~/App/User/*.module.js",
                        "~/App/User/*.controller.js",

                        /// Recipe
                        "~/App/Recipe/*.module.js",
                        "~/App/Recipe/*.controller.js",

                        /// User Admin
                        "~/App/UserAdmin/*.module.js",
                        "~/App/UserAdmin/*.controller.js",

                        /// User Administrator
                        "~/App/Administrator/*.module.js",
                        "~/App/Administrator/*.controller.js",

                        /// Directives
                        "~/App/Directives/*.module.js",
                        "~/App/Directives/*.directive.js"
                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/user-admin.css",
                      "~/Scripts/bower_components/angular-bootstrap-lightbox/dist/angular-bootstrap-lightbox.css"
                      ));
        }
    }
}
