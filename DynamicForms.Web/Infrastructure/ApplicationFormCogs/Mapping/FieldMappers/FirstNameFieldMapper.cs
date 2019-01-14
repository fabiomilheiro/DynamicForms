using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class FirstNameFieldMapper : FieldMapperBase<FirstNameField>
    {
        protected override IEnumerable<Mapping<FirstNameField>> Mappings => new[]
        {
            new Mapping<FirstNameField>(f => f.Value, a => a.Applicants[0].FirstName) 
        };
    }
}