using System;
using System.Collections.Generic;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Web.Infrastructure.Logging;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class DateOfBirthFieldMapper : FieldMapperBase<DateOfBirthField>
    {
        protected override IEnumerable<Mapping<DateOfBirthField>> Mappings => new Mapping<DateOfBirthField>[] {};

        protected override void MapToApplication(Application application, DateOfBirthField field)
        {
            try
            {
                application.Applicants[0].DateOfBirth = new DateTime(
                    field.Year.Value.ToInteger(),
                    field.Month.Value.ToInteger(),
                    field.Day.Value.ToInteger());
            }
            catch (Exception e)
            {
                Logger.Current.LogDebug<DateOfBirthFieldMapper>($"Date of birth '{field.Year.Value}-{field.Month.Value}-{field.Day.Value}' is invalid.");
            }
        }

        protected override void MapToField(Application application, DateOfBirthField field)
        {
            if (application.Applicants[0].DateOfBirth == DateTime.MinValue)
            {
                return;
            }

            field.Year.Value = application.Applicants[0].DateOfBirth.Year.ToString();
            field.Month.Value = application.Applicants[0].DateOfBirth.Month.ToString();
            field.Day.Value = application.Applicants[0].DateOfBirth.Day.ToString();
        }
    }
}