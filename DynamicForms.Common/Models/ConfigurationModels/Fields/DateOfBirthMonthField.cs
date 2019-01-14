using DynamicForms.Common.Infrastructure.Helpers;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class DateOfBirthMonthField : DropDownListField
    {
        public DateOfBirthMonthField()
        {
            Label = "Month";
            AvailableValues = DateSelectListGenerator.RetrieveMonthsOfTheYear();
        }
    }
}