using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class CitizenshipFieldMapper : FieldMapperBase<CitizenshipField>
    {
        protected override IEnumerable<Mapping<CitizenshipField>> Mappings => new[]
        {
            new Mapping<CitizenshipField>(f => f.Value, a => a.Applicants[0].CitizenshipID)
        };
    }
}