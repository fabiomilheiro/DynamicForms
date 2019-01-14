using System.Collections.Generic;

namespace DynamicForms.Common.Models.ConfigurationModels
{
    public class FormConfigurationGroup
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int ActiveVersionID { get; set; }

        public FormConfiguration ActiveVersion { get; set; }

        public List<FormConfiguration> Versions { get; set; }
    }
}