using System.Collections.Generic;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json.Attributes;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class EmailField : FieldBase
    {
        public EmailField()
        {
            Validators = new List<ValidatorBase>
            {
                new IsRequiredValidator(),
                new MustBeValidEmailAddressValidator()
            };
        }

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