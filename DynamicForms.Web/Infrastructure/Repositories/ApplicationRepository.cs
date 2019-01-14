using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json;
using DynamicForms.Common.Models.ApplicationModels;

namespace DynamicForms.Web.Infrastructure.Repositories
{
    public interface IApplicationRepository
    {
        Application RetrieveApplication(string id);

        void SaveApplication(Application application);
    }

    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IApplicationSettings applicationSettings;
        private readonly IJsonSerializerSettingsFactory jsonSerializationSettingsFactory;

        public ApplicationRepository(IApplicationSettings applicationSettings, IJsonSerializerSettingsFactory jsonSerializationSettingsFactory)
        {
            this.applicationSettings = applicationSettings;
            this.jsonSerializationSettingsFactory = jsonSerializationSettingsFactory;
        }

        public Application RetrieveApplication(string id)
        {
            using (var client = new HttpClient())
            {
                var result = client.GetStringAsync(applicationSettings.DataApiUrl + $"application/{id}").Result;
                return JsonConvert.DeserializeObject<Application>(result, jsonSerializationSettingsFactory.Create());
            }
        }

        public void SaveApplication(Application application)
        {
            using (var client = new HttpClient())
            {
                var result = client
                                .PostAsync(
                                        applicationSettings.DataApiUrl + "application",
                                        new StringContent(
                                                JsonConvert.SerializeObject(
                                                                application,
                                                                jsonSerializationSettingsFactory.Create()),
                                                Encoding.UTF8,
                                                "application/json"))
                                .Result;
                application.ID = JsonConvert.DeserializeObject<Application>(
                                                result.Content.ReadAsStringAsync().Result,
                                                jsonSerializationSettingsFactory.Create()).ID;
            }
        }
    }
}