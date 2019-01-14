using System;
using System.Reflection;

namespace DynamicForms.Common.Infrastructure.Extensions
{
    public static class TypeExtensions
    {
        public static bool IsConcreteClass(this Type type)
        {
            var typeInfo = type.GetTypeInfo();

            return typeInfo.IsClass && !typeInfo.IsInterface && !typeInfo.IsAbstract;
        }

        public static bool IsConcreteClassOf(this Type type, Type baseType)
        {
            return type.IsConcreteClass() && baseType.IsAssignableFrom(type);
        }
    }
}