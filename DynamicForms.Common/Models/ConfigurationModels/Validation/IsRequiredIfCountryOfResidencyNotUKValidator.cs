namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class IsRequiredIfCountryOfResidencyNotUKValidator : ValidatorBase<string>
    {
        public override string Description => "Must provide Tax ID except if country of residency is not United Kingdom.";
    }
}