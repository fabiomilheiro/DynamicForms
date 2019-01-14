using System;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class JsonRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IJsonSerializerSettingsFactory, JsonSerializerSettingsFactory>();
            var jsonConverterTypes = typeof(JsonRegistrations)
                .GetTypeInfo()
                .Assembly
                .GetTypes()
                .Where(t => typeof(JsonConverter).IsAssignableFrom(t) && IsConcreteClass(t))
                .ToList();

            foreach (var jsonConverterType in jsonConverterTypes)
            {
                container.RegisterType(typeof(JsonConverter), jsonConverterType, jsonConverterType.FullName);
            }
        }

        private static bool IsConcreteClass(Type t)
        {
            var typeInfo = t.GetTypeInfo();
            return typeInfo.IsClass && !typeInfo.IsAbstract;
        }
    }
}