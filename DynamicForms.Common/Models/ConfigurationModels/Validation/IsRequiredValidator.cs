using System.Collections.Generic;

namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class IsRequiredValidator : ValidatorBase
    {
        public override string Description => "The field is required.";

        public override FieldValidationResult Validate(object value, FieldValidationContext context)
        {
            if (value == null)
            {
                return new FieldValidationResult
                {
                    ErrorMessage = "The field is required."
                };
            }

            var valueAsList = value as List<string>;

            if (valueAsList != null)
            {
                if (valueAsList.Count == 0)
                {
                    return new FieldValidationResult
                    {
                        ErrorMessage = "The field is required."
                    };
                }

                return null;
            }

            if (value is bool)
            {
                if (!(bool)value)
                {
                    return new FieldValidationResult
                    {
                        ErrorMessage = "The field is required."
                    };
                }

                return null;
            }

            var valueAsString = value as string;
            if (string.IsNullOrEmpty(valueAsString))
            {

                return new FieldValidationResult
                {
                    ErrorMessage = "The field is required."
                };
            }

            return null;
        }
    }
}