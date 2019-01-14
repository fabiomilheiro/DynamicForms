using System;
using System.Globalization;
using System.Reflection;

namespace DynamicForms.Common.Infrastructure.Helpers
{
    public interface IPropertyValueRetriever
    {
        TProperty RetrievePropertyValue<TProperty>(object model, string propertyPath);
    }

    public class PropertyValueRetriever : IPropertyValueRetriever
    {
        public virtual TProperty RetrievePropertyValue<TProperty>(object model, string propertyPath)
        {
            if (string.IsNullOrEmpty(propertyPath))
            {
                throw new ArgumentNullException(nameof(propertyPath));
            }

            var parts = propertyPath.Split('.');
            object lastValue = model;
            PropertyInfo lastProperty = null;
            foreach (var propertyName in parts)
            {
                lastProperty = lastValue.GetType().GetProperty(propertyName);

                if (lastProperty == null)
                {
                    throw new PropertyValueRetrieverException(string.Format(CultureInfo.InvariantCulture,
                        "The property '{0}.{1}' does not exist.", model.GetType().Name, propertyName));
                }

                lastValue = lastProperty.GetValue(lastValue);
            }

            var propertyType = typeof(TProperty);

            if (!propertyType.IsAssignableFrom(lastProperty.PropertyType))
            {
                throw new PropertyValueRetrieverException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "The property '{0}.{1}' was found but is expected to be of '{2}' type. Either set the right property or correct to its data type.",
                        model.GetType().Name,
                        propertyPath,
                        typeof(TProperty).Name));
            }

            return (TProperty) lastValue;
        }
    }
}