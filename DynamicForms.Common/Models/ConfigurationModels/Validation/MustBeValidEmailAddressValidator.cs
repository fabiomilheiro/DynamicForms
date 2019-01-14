namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class MustBeValidEmailAddressValidator : ValidatorBase<string>
    {
        public override string Description => "Email address must be a valid email address.";
    }
}