using System.Collections.Generic;

namespace DynamicForms.Common.Models.ConfigurationModels
{
    public class Step
    {
        public int Number { get; set; }

        public string Title { get; set; }

        public List<Section> Sections { get; set; }
    }
}