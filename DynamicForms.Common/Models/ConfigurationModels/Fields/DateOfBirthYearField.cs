using DynamicForms.Common.Infrastructure.Helpers;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class DateOfBirthYearField : DropDownListField
    {
        public DateOfBirthYearField()
        {
            Label = "Year";
            AvailableValues = DateSelectListGenerator.RetrieveYears();
        }
    }
}