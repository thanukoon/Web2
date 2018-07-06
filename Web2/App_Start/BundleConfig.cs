using System.Web;
using System.Web.Optimization;

namespace Web2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/Scripts/all").Include(
                       "~/Scripts/vue.js",
                        "~/Scripts/resource.js",
                        "~/Scripts/jquery-3.3.1.js",
                        "~/Scripts/bootstrap.js"
                        ));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));
        }
    }
}
