using System;
using System.Collections;
using System.Linq;
using System.Reflection;

namespace DynamicForms.Web.Infrastructure.Helpers
{
    public interface IMerger
    {
        void Merge<TEntity>(TEntity source, TEntity destination);
    }

    public class Merger : IMerger
    {
        public void Merge<TEntity>(TEntity source, TEntity destination)
        {
            MergeDeep(source, destination);
        }

        private static void MergeDeep(object source, object destination)
        {
            var properties = destination.GetType().GetProperties().Where(p => p.CanWrite && p.CanRead);

            foreach (var property in properties)
            {
                var getter = property.GetGetMethod();
                MergeProperty(destination, source, getter, property);
            }
        }

        private static void MergeProperty(object destination, object source, MethodInfo getter, PropertyInfo property,
            params object[] getterParameters)
        {
            var destinationValue = getter.Invoke(destination, getterParameters);
            var sourceValue = getter.Invoke(source, getterParameters);

            if (destinationValue == null)
            {
                AssignSourceToDestination(destination, property, sourceValue);
            }
            else if (property.PropertyType.IsValueType &&
                     destinationValue.Equals(Activator.CreateInstance(property.PropertyType)))
            {
                AssignSourceToDestination(destination, property, sourceValue);
            }
            else if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType) && sourceValue != null)
            {
                var destinationCollection = ((IEnumerable) destinationValue).Cast<object>().ToArray();
                var sourceCollection = ((IEnumerable) sourceValue).Cast<object>().ToArray();

                if (!destinationCollection.Any())
                {
                    AssignSourceToDestination(destination, property, sourceValue);
                }
                else if (destinationCollection.Count() == sourceCollection.Count())
                {
                    var indexer = destinationValue.GetType()
                        .GetProperties()
                        .FirstOrDefault(p => p.GetIndexParameters().Any());
                    if (indexer != null)
                    {
                        for (var index = 0; index < destinationCollection.Length; index++)
                        {
                            MergeProperty(destinationValue, sourceValue, indexer.GetGetMethod(), indexer, index);
                        }
                    }
                }
            }
            else if (!property.PropertyType.IsValueType && sourceValue != null)
            {
                MergeDeep(sourceValue, destinationValue);
            }
        }

        private static void AssignSourceToDestination(object destination, PropertyInfo property, object sourceValue)
        {
            var setter = property.GetSetMethod();
            setter.Invoke(destination, new[] {sourceValue});
        }
    }
}