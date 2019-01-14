using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json.Attributes;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class TaxResidencyTaxIDField : FieldBase
    {
        [Presentation]
        public string Label { get; set; }

        [Presentation]
        public string Subtext { get; set; }

        [Presentation]
        public string Placeholder { get; set; }

        [JsonIgnore]
        public string Value { get; set; }


    }
}