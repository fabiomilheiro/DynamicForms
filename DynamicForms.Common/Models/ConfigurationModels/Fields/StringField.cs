using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json.Attributes;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class StringField : FieldBase
    {
        [Presentation]
        public string Label { get; set; }

        [Presentation]
        public string Placeholder { get; set; }

        [Presentation]
        public string Subtext { get; set; }

        [JsonIgnore]
        public string Value { get; set; }
    }
}