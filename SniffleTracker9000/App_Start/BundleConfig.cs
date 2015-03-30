using System.Web;
using System.Web.Optimization;

namespace SniffleTracker9000
{
    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js", "~/Scripts/respond.js"));
            bundles.Add(new ScriptBundle("~/bundles/knockout").Include("~/Scripts/knockout-3.3.0.js", "~/Scripts/knockout.mapping-latest.js"));
            bundles.Add(new ScriptBundle("~/bundles/moment").Include("~/Scripts/moment.js"));
            bundles.Add(new ScriptBundle("~/bundles/site").Include("~/Scripts/Site.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/site.css"));
        }
    }
}
