using System.Collections.Generic;
using System.Threading;
using System.Web.Mvc;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Time;
using DynamicForms.Common.Models.ConfigurationModels.Fields;

namespace DynamicForms.Common.Infrastructure.Helpers
{
    public static class DateSelectListGenerator
    {
        public static List<AvailableValue> RetrieveDaysOfTheMonth()
        {
            var daysOfTheMonth = new List<AvailableValue>();

            var day = 1;
            while (day <= 31)
            {
                daysOfTheMonth.Add(new AvailableValue
                {
                    Value = day.ToStringWithInvariantCulture(),
                    Text = day.ToStringWithInvariantCulture()
                });
                day++;
            }

            return daysOfTheMonth;
        }

        public static List<AvailableValue> RetrieveMonthsOfTheYear()
        {
            var culture = Thread.CurrentThread.CurrentCulture;

            var result = new List<AvailableValue>();

            var month = 1;
            while (month <= 12)
            {
                result.Add(new AvailableValue
                {
                    Value = month.ToStringWithInvariantCulture(),
                    Text = culture.DateTimeFormat.GetMonthName(month)
                });
                month++;
            }

            return result;
        }

        public static List<AvailableValue> RetrieveYears()
        {
            var years = new List<AvailableValue>();
            var eighteenYearsAgo = TimeProvider.Current.UtcNow.Year - 18;
            var lowerLimit = TimeProvider.Current.UtcNow.Year - 86;

            var year = eighteenYearsAgo;
            while (year >= lowerLimit)
            {
                years.Add(new AvailableValue
                {
                    Value = year.ToStringWithInvariantCulture(),
                    Text = year.ToStringWithInvariantCulture()
                });
                year--;
            }

            return years;
        }
    }
}