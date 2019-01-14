namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class MustBeValidDateValidator : ValidatorBase
    {
        public override string Description => "Must be valid date.";
        public override FieldValidationResult Validate(object value, FieldValidationContext context)
        {
            return null;
        }
    }
}