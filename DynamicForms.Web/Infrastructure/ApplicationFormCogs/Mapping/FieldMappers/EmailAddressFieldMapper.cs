using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class EmailFieldMapper : FieldMapperBase<EmailField>
    {
        protected override IEnumerable<Mapping<EmailField>> Mappings => new[]
        {
            new Mapping<EmailField>(f => f.Value, a => a.Applicants[0].Email)
        };
    }
}