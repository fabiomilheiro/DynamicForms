namespace DynamicForms.Common.Infrastructure.Extensions
{
    public static class StringExtensions
    {
        public static int ToInteger(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return 0;
            }

            int result;
            int.TryParse(source, out result);

            return result;
        }
    }
}