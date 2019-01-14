using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Blocks;

namespace DynamicForms.Common.Models.ConfigurationModels
{
    public class Experience
    {
        public Experience()
        {
            Blocks = new List<BlockBase>();
        }

        public ExperienceAlias Alias { get; set; }

        public Navigation Navigation { get; set; }

        public List<BlockBase> Blocks { get; set; }
    }
}