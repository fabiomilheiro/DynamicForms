namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class MustMatchPasswordValidator : ValidatorBase<string>
    {
        public override string Description => "Ensure that the password is correct by specifying it a second time.";

        internal override FieldValidationResult ValidateIfSpecified(string value, FieldValidationContext context)
        {
            if (value != context.Application.Applicants[0].Password)
            {
                return new FieldValidationResult
                {
                    ErrorMessage = "Passwords must match."
                };
            }

            return null;
        }
    }
}