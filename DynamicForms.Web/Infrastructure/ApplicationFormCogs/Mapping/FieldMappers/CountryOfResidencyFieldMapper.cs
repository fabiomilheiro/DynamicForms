using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class CountryOfResidencyFieldMapper : FieldMapperBase<CountryOfResidencyField>
    {
        protected override IEnumerable<Mapping<CountryOfResidencyField>> Mappings => new[]
        {
            new Mapping<CountryOfResidencyField>(f => f.Value, a => a.Applicants[0].AddressLine1)
        };
    }
}