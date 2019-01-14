using System.Web.Mvc;
using DynamicForms.Web.Infrastructure.AspNet;

namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public class ViewEngineConfiguration : ApplicationConfigurationBase
    {
        public override void Configure()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new ApplicationFormViewEngine());
        }
    }
}