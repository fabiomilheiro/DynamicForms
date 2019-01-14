using System.Collections.Generic;
using System.Web.Http;
using Microsoft.Practices.Unity;
using DynamicForms.ConfigurationApi.App_Start;
using DynamicForms.ConfigurationApi.Infrastructure.ApplicationConfigurations;

namespace DynamicForms.ConfigurationApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            foreach (var applicationConfiguration in GetApplicationConfigurations())
            {
                applicationConfiguration.Configure(GlobalConfiguration.Configuration);
            }
        }

        private static IEnumerable<IApplicationConfiguration> GetApplicationConfigurations()
        {
            return UnityConfig.GetConfiguredContainer().ResolveAll<IApplicationConfiguration>();
        }
    }
}
