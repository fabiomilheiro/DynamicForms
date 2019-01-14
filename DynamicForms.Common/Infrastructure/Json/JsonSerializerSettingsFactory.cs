using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json.ContractResolvers;

namespace DynamicForms.Common.Infrastructure.Json
{
    public interface IJsonSerializerSettingsFactory
    {
        JsonSerializerSettings Create();
    }

    public class JsonSerializerSettingsFactory : IJsonSerializerSettingsFactory
    {
        private readonly ApplicationFormContractResolver applicationFormContractResolver;
        private readonly JsonConverter[] jsonConverters;

        public JsonSerializerSettingsFactory(ApplicationFormContractResolver applicationFormContractResolver, JsonConverter[] jsonConverters)
        {
            this.applicationFormContractResolver = applicationFormContractResolver;
            this.jsonConverters = jsonConverters;
        }

        public JsonSerializerSettings Create()
        {
            // TODO: We can define here a different contract resolver based on the current client so we serialize things differently.
            return new JsonSerializerSettings
            {
                ContractResolver = applicationFormContractResolver,
                Converters = jsonConverters,
                Binder = new ApplicationFormSerializationBinder(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore,
                ObjectCreationHandling = ObjectCreationHandling.Replace
            };
        }
    }
}