using System.Collections.Generic;
using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class CredentialsFieldMapper : FieldMapperBase<CredentialsField>
    {
        protected override IEnumerable<Mapping<CredentialsField>> Mappings => new[]
        {
            new Mapping<CredentialsField>(f => f.Username.Value, a => a.Applicants[0].Username)
        };

        protected override void MapToApplication(Application application, CredentialsField field)
        {
            var applicant = application.Applicants[0];

            if (string.IsNullOrEmpty(field.Password.Value))
            {
                return;
            }

            applicant.Password = field.Password.Value;
        }

        protected override void MapToField(Application application, CredentialsField field)
        {
            var password = application.Applicants[0].Password;

            if (!string.IsNullOrEmpty(password))
            {
                field.Password.Placeholder = field.ConfirmPassword.Placeholder = new string('*', 8);
            }
        }
    }
}