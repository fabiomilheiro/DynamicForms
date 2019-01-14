using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Common.Infrastructure.Json.Converters
{
    public class FieldConverter : JsonConverterBase<FieldBase>
    {
        private static readonly List<Type> fieldTypes = GetFieldTypes();

        public FieldConverter(IRequestWrapper requestWrapper) : base(requestWrapper)
        {
        }

        private static List<Type> GetFieldTypes()
        {
            return typeof(FieldConverter)
                .Assembly
                .GetTypes()
                .Where(t => typeof(FieldBase).IsAssignableFrom(t) && t.IsConcreteClass())
                .ToList();
        }

        public override FieldBase Create(Type objectType, JObject source)
        {
            var fieldTypeName = source["type"] + "Field";
            var fieldType = fieldTypes.SingleOrDefault(w => w.Name == fieldTypeName);
            if (fieldType == null)
            {
                throw new NotSupportedException($"There is no field named '{fieldTypeName}'. Be sure to suffix the field class with 'Field'.");
            }

            var field = (FieldBase)Activator.CreateInstance(fieldType);

            return field;
        }
    }
}