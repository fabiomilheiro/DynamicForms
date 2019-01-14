using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class TaxResidencyGroupField : FieldBase
    {
        public TaxResidencyGroupField()
        {
            IsOnlyOneTaxResidency = new YesOrNoField();
        }

        public YesOrNoField IsOnlyOneTaxResidency { get; set; }

        public TaxResidencyField TaxResidency1 { get; set; }

        public TaxResidencyField TaxResidency2 { get; set; }

        public TaxResidencyField TaxResidency3 { get; set; }
    }
}