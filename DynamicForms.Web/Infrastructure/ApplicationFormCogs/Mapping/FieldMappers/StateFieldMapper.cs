using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class StateFieldMapper : FieldMapperBase<StateField>
    {
        protected override IEnumerable<Mapping<StateField>> Mappings => new[]
        {
            new Mapping<StateField>(f => f.Value, a => a.Applicants[0].State)
        };
    }
}