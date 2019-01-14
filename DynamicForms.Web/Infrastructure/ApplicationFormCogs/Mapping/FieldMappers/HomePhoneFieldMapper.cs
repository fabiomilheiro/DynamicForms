using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class HomePhoneFieldMapper : FieldMapperBase<HomePhoneField>
    {
        protected override IEnumerable<Mapping<HomePhoneField>> Mappings => new[]
        {
            new Mapping<HomePhoneField>(f => f.Value, a => a.Applicants[0].HomePhone)
        };
    }
}