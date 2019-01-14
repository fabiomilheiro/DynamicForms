using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class FieldValidationContext
    {
        public FieldBase Field { get; set; }

        public Application Application { get; set; }

        public Application PreviousApplicationState { get; set; }

        public FormConfiguration Configuration { get; set; }
    }
}