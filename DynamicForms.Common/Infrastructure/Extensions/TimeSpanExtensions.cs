using System;
using System.Globalization;

namespace DynamicForms.Common.Infrastructure.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToFormattedString(this TimeSpan value)
        {
            return value.ToString(@"d\.hh\:mm\:ss\.fffffff", CultureInfo.InvariantCulture);
        }
    }
}