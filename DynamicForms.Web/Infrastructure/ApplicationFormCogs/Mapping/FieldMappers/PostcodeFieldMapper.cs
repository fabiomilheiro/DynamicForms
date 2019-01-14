using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class PostcodeFieldMapper : FieldMapperBase<PostcodeField>
    {
        protected override IEnumerable<Mapping<PostcodeField>> Mappings => new[]
        {
            new Mapping<PostcodeField>(f => f.Value, a => a.Applicants[0].Postcode)
        };
    }
}