using Microsoft.Practices.Unity;

namespace DynamicForms.DataApi.Infrastructure.DependencyRegistrations
{
    public interface IDependencyRegistrations
    {
        void Register(IUnityContainer container);
    }
}