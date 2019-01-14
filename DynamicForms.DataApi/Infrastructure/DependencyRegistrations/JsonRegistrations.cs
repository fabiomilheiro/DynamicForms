using System;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using DynamicForms.Common.Infrastructure.Json;

namespace DynamicForms.DataApi.Infrastructure.DependencyRegistrations
{
    public class JsonRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IJsonSerializerSettingsFactory, JsonSerializerSettingsFactory>();
            var jsonConverterTypes = typeof(JsonRegistrations)
                .Assembly
                .GetTypes()
                .Where(t => typeof(JsonConverter).IsAssignableFrom(t) && IsConcreteClass(t))
                .ToList();

            jsonConverterTypes.Add(typeof(StringEnumConverter));

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