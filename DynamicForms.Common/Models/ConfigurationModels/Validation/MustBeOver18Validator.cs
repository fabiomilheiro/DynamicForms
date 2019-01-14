namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class MustBeOver18Validator : ValidatorBase
    {
        public override string Description => "Must be an adult.";
        public override FieldValidationResult Validate(object value, FieldValidationContext context)
        {
            return null;
        }
    }
}