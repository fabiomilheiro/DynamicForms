using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class LastNameFieldMapper : FieldMapperBase<LastNameField>
    {
        protected override IEnumerable<Mapping<LastNameField>> Mappings => new[]
        {
            new Mapping<LastNameField>(f => f.Value, a => a.Applicants[0].LastName)
        };
    }
}