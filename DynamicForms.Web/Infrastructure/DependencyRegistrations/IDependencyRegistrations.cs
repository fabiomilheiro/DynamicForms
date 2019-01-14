using Microsoft.Practices.Unity;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public interface IDependencyRegistrations
    {
        void Register(IUnityContainer container);
    }
}