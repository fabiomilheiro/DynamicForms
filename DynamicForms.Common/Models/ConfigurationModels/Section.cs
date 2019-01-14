using System.Collections.Generic;
using Newtonsoft.Json;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Common.Models.ConfigurationModels
{
    public class Section
    {
        public Section()
        {
            Body = new List<string>();
            Fields = new List<FieldBase>();
        }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }


        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Body { get; set; }

        public List<FieldBase> Fields { get; set; }
    }
}