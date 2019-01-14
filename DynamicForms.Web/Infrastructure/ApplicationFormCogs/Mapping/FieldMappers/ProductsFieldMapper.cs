using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping.FieldMappers
{
    public class ProductsFieldMapper : FieldMapperBase<ProductsField>
    {
        protected override IEnumerable<Mapping<ProductsField>> Mappings => new[]
        {
            new Mapping<ProductsField>(f => f.Value, a => a.SelectedProducts)
        };
    }
}