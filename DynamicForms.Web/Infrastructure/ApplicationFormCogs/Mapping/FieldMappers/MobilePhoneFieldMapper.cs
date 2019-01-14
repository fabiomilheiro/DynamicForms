using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class MobilePhoneFieldMapper : FieldMapperBase<MobilePhoneField>
    {
        protected override IEnumerable<Mapping<MobilePhoneField>> Mappings => new[]
        {
            new Mapping<MobilePhoneField>(f => f.Value, a => a.Applicants[0].MobilePhone)
        };
    }
}