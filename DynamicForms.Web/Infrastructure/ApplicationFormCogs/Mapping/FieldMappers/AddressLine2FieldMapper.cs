using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class AddressLine2FieldMapper : FieldMapperBase<AddressLine2Field>
    {
        protected override IEnumerable<Mapping<AddressLine2Field>> Mappings => new[]
        {
            new Mapping<AddressLine2Field>(f => f.Value, a => a.Applicants[0].AddressLine2)
        };
    }
}