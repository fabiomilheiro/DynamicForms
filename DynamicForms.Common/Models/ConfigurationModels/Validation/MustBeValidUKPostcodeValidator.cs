namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class MustBeValidUKPostcodeValidator : ValidatorBase
    {
        public override string Description => "Must be valid UK postcode";
        public override FieldValidationResult Validate(object value, FieldValidationContext context)
        {
            return null;
        }
    }
}