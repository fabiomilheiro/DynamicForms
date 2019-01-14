using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class TaxResidencyField : FieldBase
    {
        public TaxResidencyCountryField Country { get; set; }

        public TaxResidencyTaxIDField TaxID { get; set; }
    }
}