namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class StringLengthValidator : ValidatorBase<string>
    {
        public override string Description => "The field length must be between the limits established.";

        public int MinimumLength { get; set; }

        public int MaximumLength { get; set; }

        internal override FieldValidationResult ValidateIfSpecified(string value, FieldValidationContext context)
        {
            if (value.Length < MinimumLength || value.Length > MaximumLength)
            {
                return new FieldValidationResult
                {
                    ErrorMessage = $"The field must be between {MinimumLength} and {MaximumLength} characters."
                };
            }

            return null;
        }
    }
}