using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DynamicForms.Common.Infrastructure.Extensions;
using Microsoft.Practices.Unity;
using DynamicForms.Web.Infrastructure.ApplicationConfigurations;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class ApplicationConfigurationRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            foreach (var configurationType in GetApplicationConfigurationTypes())
            {
                container.RegisterType(typeof(IApplicationConfiguration), configurationType, configurationType.FullName);
            }
        }

        private IEnumerable<Type> GetApplicationConfigurationTypes()
        {
            return typeof(MvcApplication)
                .GetTypeInfo()
                .Assembly
                .GetTypes()
                .Where(t => typeof(IApplicationConfiguration).IsAssignableFrom(t) && t.IsConcreteClass());
        }
    }
}