using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class CityFieldMapper : FieldMapperBase<CityField>
    {
        protected override IEnumerable<Mapping<CityField>> Mappings => new[]
        {
            new Mapping<CityField>(f => f.Value, a => a.Applicants[0].City)
        };
    }
}