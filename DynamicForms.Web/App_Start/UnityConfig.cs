using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using DynamicForms.Web.Infrastructure.DependencyRegistrations;
using System;
using DynamicForms.Common.Infrastructure.Extensions;

namespace DynamicForms.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            foreach (var dependencyRegistrations in GetDependencyRegistrations())
            {
                dependencyRegistrations.Register(container);
            }

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        public static List<IDependencyRegistrations> GetDependencyRegistrations()
        {
            var types = typeof(MvcApplication)
                .Assembly
                .GetTypes();

            var dependencyRegistrationTypes = types
                .Where(t => typeof(IDependencyRegistrations).IsAssignableFrom(t) && t.IsConcreteClass())
                .Select(t => (IDependencyRegistrations) Activator.CreateInstance(t))
                .ToList();

            return dependencyRegistrationTypes;
        }
    }
}