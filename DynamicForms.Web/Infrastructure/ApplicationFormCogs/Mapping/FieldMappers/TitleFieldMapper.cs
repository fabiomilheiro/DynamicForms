using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class TitleFieldMapper : FieldMapperBase<TitleField>
    {
        protected override IEnumerable<Mapping<TitleField>> Mappings => new[]
        {
            new Mapping<TitleField>(f => f.Value, a => a.Applicants[0].TitleID)
        };
    }
}