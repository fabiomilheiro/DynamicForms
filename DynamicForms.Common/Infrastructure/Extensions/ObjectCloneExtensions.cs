using Newtonsoft.Json;

namespace DynamicForms.Common.Infrastructure.Extensions
{
    public static class ObjectCloneExtensions
    {
        public static T Clone<T>(this T source) where T : class
        {
            var serialised = JsonConvert.SerializeObject(source);

            return JsonConvert.DeserializeObject<T>(serialised);
        }
    }
}