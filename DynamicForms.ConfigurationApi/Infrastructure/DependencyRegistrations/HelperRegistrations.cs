using Microsoft.Practices.Unity;
using DynamicForms.Common.Infrastructure.Helpers;

namespace DynamicForms.ConfigurationApi.Infrastructure.DependencyRegistrations
{
    public class HelperRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IRequestWrapper, RequestWrapper>();
        }
    }
}