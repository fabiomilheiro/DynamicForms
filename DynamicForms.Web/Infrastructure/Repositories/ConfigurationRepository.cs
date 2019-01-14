using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json;
using DynamicForms.Common.Models.ConfigurationModels;

namespace DynamicForms.Web.Infrastructure.Repositories
{
    public interface IConfigurationRepository
    {
        FormConfiguration RetrieveConfiguration(string id);

        FormConfiguration RetrieveConfiguration(string id, int versionId);
        List<FormConfiguration> RetrieveConfigurations();
    }

    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IApplicationSettings applicationSettings;
        private readonly IJsonSerializerSettingsFactory jsonSerializerSettingsFactory;

        public ConfigurationRepository(IApplicationSettings applicationSettings,
            IJsonSerializerSettingsFactory jsonSerializerSettingsFactory)
        {
            this.applicationSettings = applicationSettings;
            this.jsonSerializerSettingsFactory = jsonSerializerSettingsFactory;
        }

        public FormConfiguration RetrieveConfiguration(string id)
        {

            return GetFromCache($"RetrieveConfiguration-{id}", () =>
                    {
                        using (var client = new HttpClient())
                        {
                            var apiResponse = GetApiFormConfiguration(client, id);
                            return JsonConvert.DeserializeObject<FormConfiguration>(apiResponse,
                                jsonSerializerSettingsFactory.Create());

                        }
                    });
        }

        public FormConfiguration RetrieveConfiguration(string id, int versionID)
        {

            return GetFromCache(
                    $"RetrieveConfiguration-{id},{versionID}", () =>
                    {
                        using (var client = new HttpClient())
                        {
                            var apiResponse = GetApiFormConfiguration(client, id, versionID);
                            return JsonConvert.DeserializeObject<FormConfiguration>(apiResponse, jsonSerializerSettingsFactory.Create());
                        }
                    });
        }

        public List<FormConfiguration> RetrieveConfigurations()
        {
            return GetFromCache(
                "RetrieveAllConfigurations", () =>
                {
                    using (var client = new HttpClient())
                    {
                        var apiResponse = client.GetStringAsync(applicationSettings.ConfigurationApiUrl + "form").Result;
                        return JsonConvert.DeserializeObject<List<FormConfiguration>>(apiResponse, jsonSerializerSettingsFactory.Create());
                    }
                });
        }

        private T GetFromCache<T>(string key, System.Func<T> getter) where T : class
        {
            if (!applicationSettings.EnableCache)
            {
                return getter();
            }

            var result = HttpRuntime.Cache.Get(key) as T;

            if (result != null)
            {
                return result;
            }

            result = getter();

            HttpRuntime.Cache.Insert(key, result, null, DateTime.UtcNow, TimeSpan.Zero);

            return result;
        }

        private string GetApiFormConfiguration(HttpClient client, string id)
        {
            return client.GetStringAsync(applicationSettings.ConfigurationApiUrl +
                                         $"form/{id}/?clientType=InternalApplicationForms")
                .Result;
        }

        private string GetApiFormConfiguration(HttpClient client, string id, int versionID)
        {
            return client.GetStringAsync(applicationSettings.ConfigurationApiUrl +
                                         $"form/{id}/{versionID}?clientType=InternalApplicationForms")
                .Result;
        }
    }
}