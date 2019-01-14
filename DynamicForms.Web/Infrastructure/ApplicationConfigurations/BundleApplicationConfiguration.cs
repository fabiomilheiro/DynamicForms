using System.Web.Optimization;
using DynamicForms.Common.Models.ConfigurationModels;

namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public class BundleApplicationConfiguration : ApplicationConfigurationBase
    {
        public override void Configure()
        {
            var bundles = BundleTable.Bundles;

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                "~/Scripts/bootstrap.js"));

            foreach (var theme in typeof(BrandTheme).GetEnumNames())
            {
                bundles.Add(new StyleBundle($"~/Content/styles/{theme}").Include(
                    "~/Content/bootstrap.css",
                    "~/Content/site.css",
                    $"~/Content/themes/{theme}.css"));
            }
        }
    }
}