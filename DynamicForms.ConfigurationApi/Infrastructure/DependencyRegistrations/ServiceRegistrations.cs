using Microsoft.Practices.Unity;
using DynamicForms.ConfigurationApi.Infrastructure.ConfigurationCogs;

namespace DynamicForms.ConfigurationApi.Infrastructure.DependencyRegistrations
{
    public class ServiceRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IFormConfigurationService, FormConfigurationService>();
        }
    }
}