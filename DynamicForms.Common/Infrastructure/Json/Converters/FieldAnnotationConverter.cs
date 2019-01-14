using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ConfigurationModels.FieldAnnotations;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Common.Infrastructure.Json.Converters
{
    public class FieldAnnotationConverter : JsonConverterBase<FieldAnnotationBase>
    {
        private static readonly List<Type> fieldAnnotationTypes = GetFieldAnnotationTypes();

        public FieldAnnotationConverter(IRequestWrapper requestWrapper) : base(requestWrapper)
        {
        }

        private static List<Type> GetFieldAnnotationTypes()
        {
            return typeof(FieldAnnotationConverter)
                .Assembly
                .GetTypes()
                .Where(t => typeof(FieldAnnotationBase).IsAssignableFrom(t) && t.IsConcreteClass())
                .ToList();
        }

        public override FieldAnnotationBase Create(Type objectType, JObject source)
        {
            var fieldAnnotationTypeName = source["type"] + "FieldAnnotation";
            var fieldAnnotationType = fieldAnnotationTypes.SingleOrDefault(w => w.Name == fieldAnnotationTypeName);
            if (fieldAnnotationType == null)
            {
                throw new NotSupportedException(
                    $"There is no field annotation named '{fieldAnnotationTypeName}'. Be sure to suffix the field annotationclass with 'FieldAnnotation'.");
            }

            var field = (FieldAnnotationBase) Activator.CreateInstance(fieldAnnotationType);

            return field;
        }
    }
}