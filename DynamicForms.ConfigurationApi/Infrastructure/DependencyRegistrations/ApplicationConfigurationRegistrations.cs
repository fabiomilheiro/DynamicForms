using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using DynamicForms.ConfigurationApi.Infrastructure.ApplicationConfigurations;

namespace DynamicForms.ConfigurationApi.Infrastructure.DependencyRegistrations
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
            return typeof(WebApiApplication)
                .Assembly
                .GetTypes()
                .Where(t => typeof(IApplicationConfiguration).IsAssignableFrom(t) && t.GetTypeInfo().IsClass);
        }
    }
}