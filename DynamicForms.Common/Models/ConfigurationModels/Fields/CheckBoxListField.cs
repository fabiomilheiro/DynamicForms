using System.Collections.Generic;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json.Attributes;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class CheckBoxListField : FieldBase
    {
        public CheckBoxListField()
        {
            AvailableValues = new List<AvailableValue>();
            Value = new List<string>();
        }

        [Presentation]
        public string Label { get; set; }

        [Presentation]
        public string Subtext { get; set; }

        [JsonIgnore]
        public List<string> Value { get; set; }


        public List<AvailableValue> AvailableValues { get; set; }
    }
}