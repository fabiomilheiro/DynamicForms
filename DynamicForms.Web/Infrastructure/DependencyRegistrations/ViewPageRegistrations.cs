using System.Web.Mvc;
using Microsoft.Practices.Unity;
using DynamicForms.Web.Infrastructure.AspNet;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class ViewPageRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IViewPageActivator, ApplicationFormViewPageActivator>();
        }
    }
}