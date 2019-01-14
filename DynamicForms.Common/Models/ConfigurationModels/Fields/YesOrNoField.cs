using System.Collections.Generic;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class YesOrNoField : RadioButtonListField
    {
        public YesOrNoField()
        {
            AvailableValues = new List<AvailableValue>
            {
                new AvailableValue
                {
                    Value = true.ToString(),
                    Text = "Yes"
                },
                new AvailableValue
                {
                    Value = false.ToString(),
                    Text = "No",
                    SubtextOnSelection = "You can provide up to a 3 additional tax residencies"
                }
            };
        }
    }
}