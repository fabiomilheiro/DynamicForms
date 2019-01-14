using System.Web.Http;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json;

namespace DynamicForms.ConfigurationApi.Infrastructure.ApplicationConfigurations
{
    public class JsonConfiguration : IApplicationConfiguration
    {
        private readonly IJsonSerializerSettingsFactory jsonSerializationSettingsFactory;

        public JsonConfiguration(IJsonSerializerSettingsFactory jsonSerializationSettingsFactory)
        {
            this.jsonSerializationSettingsFactory = jsonSerializationSettingsFactory;
        }

        public void Configure(HttpConfiguration configuration)
        {
            configuration.Formatters.Insert(0, new VariantJsonMediaTypeFormatter(jsonSerializationSettingsFactory));
            configuration.Formatters.JsonFormatter.SerializerSettings = jsonSerializationSettingsFactory.Create();
            configuration.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;
            JsonConvert.DefaultSettings = () => jsonSerializationSettingsFactory.Create();
        }
    }
}