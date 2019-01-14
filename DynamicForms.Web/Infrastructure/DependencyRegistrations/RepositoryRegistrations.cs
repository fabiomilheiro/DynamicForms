using Microsoft.Practices.Unity;
using DynamicForms.Web.Infrastructure.Repositories;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class RepositoryRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IConfigurationRepository, ConfigurationRepository>();
        }
    }
}