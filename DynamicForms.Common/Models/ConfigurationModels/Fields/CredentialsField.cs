using DynamicForms.Common.Infrastructure.Json.Attributes;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class CredentialsField : FieldBase
    {
        [Presentation]
        public bool EnableClearTextButton { get; set; }

        public StringField Username { get; set; }

        public PasswordField Password { get; set; }

        public ConfirmPasswordField ConfirmPassword { get; set; }
    }
}