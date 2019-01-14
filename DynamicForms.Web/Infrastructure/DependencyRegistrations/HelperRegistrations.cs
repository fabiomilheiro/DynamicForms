using Microsoft.Practices.Unity;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;
using DynamicForms.Web.Infrastructure.Helpers;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class HelperRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IRequestWrapper, RequestWrapper>(new ContainerControlledLifetimeManager());
            container.RegisterType<IMerger, Merger>(new ContainerControlledLifetimeManager());
            container.RegisterType<IPropertyValueRetriever, PropertyValueRetriever>(new ContainerControlledLifetimeManager());
            container.RegisterType<IApplicationSettings, ApplicationSettings>(new ContainerControlledLifetimeManager());
        }
    }
}