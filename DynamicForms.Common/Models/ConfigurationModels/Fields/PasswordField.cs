using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class PasswordField : StringField
    {
        public PasswordField()
        {
            Validators = new List<ValidatorBase>
            {
                new IsPasswordRequiredOnceValidator(),
                new StringLengthValidator
                {
                    MinimumLength = 8,
                    MaximumLength = 15
                },
                new PasswordRegexValidator()
            };

        }
    }
}