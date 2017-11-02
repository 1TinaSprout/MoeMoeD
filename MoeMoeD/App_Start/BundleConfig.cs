using System.Web;
using System.Web.Optimization;

namespace MoeMoeD
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").Include(
                        "~/Scripts/vue.js",
                        "~/Scripts/iview.js",
                        "~/Scripts/axios.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/Content/iview.css",
                      "~/Content/site.css"));
        }
    }
}
