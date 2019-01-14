using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Common.Models.ConfigurationModels
{
    public class FormConfiguration
    {
        public FormConfiguration()
        {
            Settings = new Settings();
        }

        public int VersionID { get; set; }

        public DateTime CreationDate { get; set; }
        
        public FormConfigurationGroup Group { get; set; }

        public Settings Settings { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<Experience> Experiences { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<FieldBase> Fields { get; set; }
    }
}