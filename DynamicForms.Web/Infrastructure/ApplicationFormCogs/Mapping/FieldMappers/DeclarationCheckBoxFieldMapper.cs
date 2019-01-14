using System;
using System.Linq;
using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class DeclarationCheckBoxFieldMapper : FieldMapperBase<DeclarationCheckBoxField>
    {
        protected override void MapToApplication(Application application, DeclarationCheckBoxField field)
        {
            var declarationAnswers = application.Applicants[0].Declarations;

            var answer = GetAnswer(application, field);

            if (answer != null)
            {
                answer.Value = field.Value;
                return;
            }

            declarationAnswers.Add(new Declaration
            {
                Alias = field.Alias,
                Value = field.Value
            });
        }

        protected override void MapToField(Application application, DeclarationCheckBoxField field)
        {
            var answer = GetAnswer(application, field);

            if (answer != null)
            {
                field.Value = Convert.ToBoolean(answer.Value);
            }
        }

        private static Declaration GetAnswer(Application application, DeclarationCheckBoxField field)
        {
            return application.Applicants[0].Declarations.SingleOrDefault(d => d.Alias == field.Alias);
        }
    }
}