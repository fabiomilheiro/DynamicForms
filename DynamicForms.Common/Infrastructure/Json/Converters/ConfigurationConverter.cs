using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models;
using DynamicForms.Common.Models.ConfigurationModels;

namespace DynamicForms.Common.Infrastructure.Json.Converters
{
    public class ConfigurationConverter : JsonConverterBase<FormConfiguration>
    {
        public ConfigurationConverter(IRequestWrapper requestWrapper) : base(requestWrapper)
        {
        }
    }
}