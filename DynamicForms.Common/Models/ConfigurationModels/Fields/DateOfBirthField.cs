using DynamicForms.Common.Infrastructure.Helpers;

namespace DynamicForms.Common.Models.ConfigurationModels.Fields
{
    public class DateOfBirthField : FieldBase
    {
        public DateOfBirthDayField Day { get; set; }

        public DateOfBirthMonthField Month { get; set; }

        public DateOfBirthYearField Year { get; set; }
    }
}