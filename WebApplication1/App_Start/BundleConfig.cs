using System.Web.Optimization;

namespace ContactInfo
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.5.1.min.js",
                "~/Scripts/bootstrap.bundle.min.js",
                "~/Scripts/umd/popper.min.js",
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
               "~/Scripts/ContactInformation.js"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                  "~/Content/bootstrap.css",
                  "~/Content/ContactInformation.css"
                  ));

            BundleTable.EnableOptimizations = true;
        }
    }
}