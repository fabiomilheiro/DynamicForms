using DynamicForms.Common.Infrastructure.Json.Attributes;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class AvailableValue
    {
        public string Value { get; set; }

        public string Text { get; set; }

        public int Score { get; set; }

        public bool IsNotAccepted { get; set; }

        [Presentation]
        public string SubtextOnSelection { get; set; }
    }
}