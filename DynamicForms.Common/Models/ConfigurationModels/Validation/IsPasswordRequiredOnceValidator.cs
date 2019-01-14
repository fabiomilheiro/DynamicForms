namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class IsPasswordRequiredOnceValidator : IsRequiredValidator
    {
        public override string Description { get; } = "The field is required until a value has been saved.";

        public override FieldValidationResult Validate(object value, FieldValidationContext context)
        {
            var validationResult = base.Validate(value, context);

            if (validationResult == null)
            {
                return null;
            }

            return base.Validate(context.PreviousApplicationState.Applicants[0].Password, context);
        }
    }
}