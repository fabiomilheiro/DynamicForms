using System.Collections.Generic;

namespace DynamicForms.Common.Models.ConfigurationModels.FieldAnnotations
{
    public class SalesforceFieldAnnotation : FieldAnnotationBase
    {
        public SalesforceFieldAnnotation()
        {
            Fields = new List<string>();
        }

        public List<string> Fields { get; set; }

        public override string ToString()
        {
            return $"Fields: {string.Join(", ", Fields)}";
        }
    }
}