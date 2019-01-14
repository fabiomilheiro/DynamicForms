using System;
using System.Web.Mvc;
using Microsoft.Practices.Unity;

namespace DynamicForms.Web.Infrastructure.AspNet
{
    public class ApplicationFormViewPageActivator : IViewPageActivator
    {
        private readonly IUnityContainer container;

        public ApplicationFormViewPageActivator(IUnityContainer container)
        {
            this.container = container;
        }

        public object Create(ControllerContext controllerContext, Type type)
        {
            return this.container.Resolve(type);
        }
    }
}