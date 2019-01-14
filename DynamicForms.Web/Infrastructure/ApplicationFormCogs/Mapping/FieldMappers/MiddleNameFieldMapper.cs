using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class MiddleNameFieldMapper : FieldMapperBase<MiddleNameField>
    {
        protected override IEnumerable<Mapping<MiddleNameField>> Mappings => new[]
        {
            new Mapping<MiddleNameField>(f => f.Value, a => a.Applicants[0].MiddleName)
        };
    }
}