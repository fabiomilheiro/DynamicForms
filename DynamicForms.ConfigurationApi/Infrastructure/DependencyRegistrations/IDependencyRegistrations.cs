using Microsoft.Practices.Unity;

namespace DynamicForms.ConfigurationApi.Infrastructure.DependencyRegistrations
{
    public interface IDependencyRegistrations
    {
        void Register(IUnityContainer container);
    }
}