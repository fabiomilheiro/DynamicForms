using Microsoft.Practices.Unity;
using DynamicForms.ConfigurationApi.Repository;

namespace DynamicForms.ConfigurationApi.Infrastructure.DependencyRegistrations
{
    public class RepositoryRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IFormConfigurationRepository, FormConfigurationRepository>();
        }
    }
}