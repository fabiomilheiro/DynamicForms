namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class MustBeUKPhoneNumberValidator : ValidatorBase<string>
    {
        public override string Description => "Must be valid UK phone number.";
    }
}