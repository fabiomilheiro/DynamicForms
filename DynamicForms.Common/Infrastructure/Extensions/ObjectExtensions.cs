using System;
using System.Globalization;

namespace DynamicForms.Common.Infrastructure.Extensions
{
    public static class ObjectExtensions
    {
        public static string ToStringWithInvariantCulture<TSource>(this TSource source)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0}", source);
        }

        public static TMember GetSafely<TSource, TMember>(this TSource source, Func<TSource, TMember> getter)
        {
            if (source == null)
            {
                return default(TMember);
            }

            return getter(source);
        }
    }
}