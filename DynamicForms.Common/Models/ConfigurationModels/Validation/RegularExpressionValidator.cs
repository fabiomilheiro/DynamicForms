using System.Text.RegularExpressions;

namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class RegularExpressionValidator : ValidatorBase<string>
    {
        public override string Description => "Ensures the value matches the regular expression.";

        public virtual string Pattern { get; set; }

        internal override FieldValidationResult ValidateIfSpecified(string value, FieldValidationContext context)
        {
            if (!Regex.IsMatch(value, Pattern, RegexOptions.IgnoreCase))
            {
                return new FieldValidationResult
                {
                    ErrorMessage = $"The field {context.Field.Type} does not match the pattern {Pattern}"
                };
            }

            return null;
        }
    }
}