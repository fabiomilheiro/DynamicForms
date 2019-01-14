using System.Collections.Generic;
using Newtonsoft.Json;
using DynamicForms.Common.Models.ConfigurationModels.FieldAnnotations;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public abstract class FieldBase
    {
        protected FieldBase()
        {
            Validators = new List<ValidatorBase>();
            Annotations = new List<FieldAnnotationBase>();
        }

        [JsonProperty(Order = -5)]
        public string Type => GetType().Name.Replace("Field", null);

        [JsonProperty(Order = -4, NullValueHandling = NullValueHandling.Ignore)]
        public string Alias { get; set; }

        [JsonProperty(Order = -3)]
        public List<ValidatorBase> Validators { get; set; }

        [JsonProperty(Order = -2)]
        public List<FieldAnnotationBase> Annotations { get; set; }
    }
}