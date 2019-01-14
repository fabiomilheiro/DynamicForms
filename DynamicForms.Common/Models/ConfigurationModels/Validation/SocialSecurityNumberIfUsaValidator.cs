namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class SocialSecurityNumberIfUsaValidator : ValidatorBase<string>
    {
        public override string Description => "Must provide valid American social security number if USA or country under USA authority e.g. Puerto Rico, American Samoa, Guam.";
    }
}