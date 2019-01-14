using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using DynamicForms.DataApi.Infrastructure.DependencyRegistrations;
using System.Linq;
using DynamicForms.Common.Infrastructure.Extensions;

namespace DynamicForms.DataApi.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            foreach (var dependencyRegistrations in GetDependencyRegistrations())
            {
                dependencyRegistrations.Register(container);
            }
            // TODO: Register your types here
            // container.RegisterType<IProductRepository, ProductRepository>();
        }

        public static IEnumerable<IDependencyRegistrations> GetDependencyRegistrations()
        {
            var types = typeof(WebApiApplication)
                .Assembly
                .GetTypes();

            var dependencyRegistrationTypes = types
                .Where(t => typeof(IDependencyRegistrations).IsAssignableFrom(t) && t.IsConcreteClass())
                .Select(t => (IDependencyRegistrations)Activator.CreateInstance(t))
                .ToList();

            return dependencyRegistrationTypes;
        }
    }
}
