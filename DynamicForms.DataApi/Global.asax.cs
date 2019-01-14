using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Microsoft.Practices.Unity;
using DynamicForms.DataApi.App_Start;
using DynamicForms.DataApi.Infrastructure.ApplicationConfigurations;

namespace DynamicForms.DataApi
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
