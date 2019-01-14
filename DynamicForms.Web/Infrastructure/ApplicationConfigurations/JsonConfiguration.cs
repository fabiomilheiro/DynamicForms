using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json;

namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public class JsonConfiguration : ApplicationConfigurationBase
    {
        private readonly IJsonSerializerSettingsFactory jsonSerializationSettingsFactory;

        public JsonConfiguration(IJsonSerializerSettingsFactory jsonSerializationSettingsFactory)
        {
            this.jsonSerializationSettingsFactory = jsonSerializationSettingsFactory;
        }

        public override void Configure()
        {
            JsonConvert.DefaultSettings = () => this.jsonSerializationSettingsFactory.Create();
        }
    }
}