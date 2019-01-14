using System;
using System.Collections.Generic;
using System.Linq;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Json.Converters;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Fields
{
    public interface IFieldFactory
    {
        FieldBase Create(string fieldTypeName);
    }

    public class FieldFactory : IFieldFactory
    {
        public FieldBase Create(string fieldTypeName)
        {
            fieldTypeName = fieldTypeName + "Field";
            var fieldType = fieldTypes.SingleOrDefault(ft => ft.Name == fieldTypeName);

            if (fieldType == null)
            {
                throw new NotSupportedException($"There is no field named '{fieldTypeName}'. Be sure to suffix the field class with 'Field'.");
            }

            return (FieldBase)Activator.CreateInstance(fieldType);
        }


        private static readonly List<Type> fieldTypes = GetFieldTypes();

        private static List<Type> GetFieldTypes()
        {
            return typeof(FieldConverter)
                .Assembly
                .GetTypes()
                .Where(t => typeof(FieldBase).IsAssignableFrom(t) && t.IsConcreteClass())
                .ToList();
        }
    }
}