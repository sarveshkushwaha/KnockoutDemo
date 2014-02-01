using System;
using System.Web;
using System.Web.Optimization;

namespace KnockoutDemo.App_Start
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {

            //Dont Include Min file Here ,MVC4 excluded those , to add those you can rename .min.js to .js or uncomment following two lines
            // bundles.IgnoreList.Clear();
            // AddDefaultIgnorePatterns(bundles.IgnoreList);

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            //            "~/Scripts/jquery-ui-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                       "~/Scripts/bootstrap.js",
                       "~/Scripts/knockout-3.0.0.js",
                       "~/Scripts/koDemo.js"
                       ));

            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                "~/Content/bootstrap.css"
                ));


            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            //set it true while deploying on production
            BundleTable.EnableOptimizations = false;

        }

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException("ignoreList");
            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            //ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
        }

    }
}