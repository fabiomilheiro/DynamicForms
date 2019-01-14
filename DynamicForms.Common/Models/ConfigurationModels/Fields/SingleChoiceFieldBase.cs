using System.Collections.Generic;
using DynamicForms.Common.Infrastructure.Json.Attributes;
using Newtonsoft.Json;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public abstract class SingleChoiceFieldBase : FieldBase
    {
        protected SingleChoiceFieldBase()
        {
            AvailableValues = new List<AvailableValue>();
        }

        [Presentation]
        public string Label { get; set; }

        [Presentation]
        public string Subtext { get; set; }

        [JsonIgnore]
        public string Value { get; set; }

        public List<AvailableValue> AvailableValues { get; set; }
    }
}