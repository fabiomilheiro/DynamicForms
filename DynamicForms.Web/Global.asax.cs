using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DynamicForms.Web.Infrastructure.ApplicationConfigurations;

namespace DynamicForms.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ExecuteApplicationConfigurations();
        }

        private static void ExecuteApplicationConfigurations()
        {
            foreach (var applicationConfiguration in GetApplicationConfigurations())
            {
                applicationConfiguration.Configure();
            }
        }

        private static IEnumerable<IApplicationConfiguration> GetApplicationConfigurations()
        {
            return DependencyResolver.Current.GetServices<IApplicationConfiguration>().Where(c => c.IsEnabled).ToList();
        }
    }
}
