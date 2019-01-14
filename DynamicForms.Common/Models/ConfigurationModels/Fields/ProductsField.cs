using System.Collections.Generic;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class ProductsField : CheckBoxListField
    {
        public ProductsField()
        {
            Validators = new List<ValidatorBase>
            {
                new IsRequiredValidator()
            };
        }
    }
}