using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class ConfirmPasswordField : PasswordField
    {
        public ConfirmPasswordField()
        {
            Validators = new List<ValidatorBase>
            {
                new MustMatchPasswordValidator()
            };
        }
    }
}