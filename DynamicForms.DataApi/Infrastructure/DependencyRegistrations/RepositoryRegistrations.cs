using Microsoft.Practices.Unity;
using DynamicForms.DataApi.Repositories;

namespace DynamicForms.DataApi.Infrastructure.DependencyRegistrations
{
    public class RepositoryRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IApplicationRepository, ApplicationRepository>(new ContainerControlledLifetimeManager());
        }
    }
}