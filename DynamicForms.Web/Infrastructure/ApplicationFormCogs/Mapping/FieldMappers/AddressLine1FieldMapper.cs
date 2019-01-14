using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class AddressLine1FieldMapper : FieldMapperBase<AddressLine1Field>
    {
        protected override IEnumerable<Mapping<AddressLine1Field>> Mappings => new[]
        {
            new Mapping<AddressLine1Field>(f => f.Value, a => a.Applicants[0].AddressLine1)
        };
    }
}