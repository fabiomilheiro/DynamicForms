namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public class PasswordRegexValidator : RegularExpressionValidator
    {
        public override string Description => "Must have least 2 of these: digit, upper case letter or lower case letter.";

        public override string Pattern =>
            "^(?=([^a-z]*[a-z]){1})(?=([^A-Z]*[A-Z]))|((?=([^A-Z]*[A-Z]){1})(?=(\\D*\\d){1}))|((?=([^a-z]*[a-z]){1})(?=(\\D*\\d){1}))[a-zA-Z0-9]+$";
    }
}