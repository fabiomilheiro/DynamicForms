using DynamicForms.Common.Infrastructure.Helpers;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class DateOfBirthDayField : DropDownListField
    {
        public DateOfBirthDayField()
        {
            Label = "Day";
            AvailableValues = DateSelectListGenerator.RetrieveDaysOfTheMonth();
        }
    }
}