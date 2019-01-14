using System.Collections.Generic;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json.Attributes;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class CountryOfResidencyField : FieldBase
    {
        public CountryOfResidencyField()
        {
            AvailableValues = new List<CountryAvailableValue>();
        }

        [Presentation]
        public string Label { get; set; }

        [Presentation]
        public string Subtext { get; set; }

        [JsonIgnore]
        public string Value { get; set; }

        public List<CountryAvailableValue> AvailableValues { get; set; }
    }

    public class CountryAvailableValue
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public CountryRedirectRule Redirect { get; set; }
    }

    public class CountryRedirectRule
    {
        public string Type { get; set; }

        public string TargetID { get; set; }
    }
}