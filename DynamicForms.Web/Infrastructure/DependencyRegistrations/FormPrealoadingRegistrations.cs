using Microsoft.Practices.Unity;
using DynamicForms.Web.Infrastructure.Caching;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class FormPreloadingRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IFormLoadStarter, FormLoadStarter>(new ContainerControlledLifetimeManager());
            container.RegisterType<IFormLoader, FormLoader>(new ContainerControlledLifetimeManager());
        }
    }
}