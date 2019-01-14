using Microsoft.Practices.Unity;
using DynamicForms.Common.Infrastructure.Helpers;

namespace DynamicForms.DataApi.Infrastructure.DependencyRegistrations
{
    public class HelperRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IRequestWrapper, RequestWrapper>();
        }
    }
}