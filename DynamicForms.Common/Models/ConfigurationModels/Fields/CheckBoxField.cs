using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json.Attributes;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class CheckBoxField : FieldBase
    {
        [Presentation]
        public string Label { get; set; }

        [JsonIgnore]
        public bool Value { get; set; }
    }
}