namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class MustBeValidUsernameValidator : ValidatorBase<string>
    {
        public override string Description => "Must be 8-50 characters. Do not include spaces or other special characters.";
    }
}