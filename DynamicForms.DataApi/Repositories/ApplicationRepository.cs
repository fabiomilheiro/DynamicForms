using System;
using System.IO;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Json;
using DynamicForms.Common.Models.ApplicationModels;

namespace DynamicForms.DataApi.Repositories
{
    public interface IApplicationRepository
    {
        Application RetrieveApplication(string id);

        void SaveApplication(Application application);
    }

    public class ApplicationRepository : IApplicationRepository
    {
        private readonly IJsonSerializerSettingsFactory jsonSerializerSettingsFactory;

        public ApplicationRepository(IJsonSerializerSettingsFactory jsonSerializerSettingsFactory)
        {
            this.jsonSerializerSettingsFactory = jsonSerializerSettingsFactory;
        }

        public Application RetrieveApplication(string id)
        {
            var filePath = GetApplicationFilePath(id);
            if (!File.Exists(filePath))
            {
                return new Application();
            }

            var content = File.ReadAllText(filePath);

            return JsonConvert.DeserializeObject<Application>(content);
        }

        private static string GetApplicationFilePath(string id)
        {
            return $"App_Data/Applications/{id}.json";
        }

        public void SaveApplication(Application application)
        {
            if (string.IsNullOrEmpty(application.ID))
            {
                application.ID = Guid.NewGuid().ToString();
            }

            File.WriteAllText(
                    GetApplicationFilePath(application.ID),
                    JsonConvert.SerializeObject(
                                    application,
                                    jsonSerializerSettingsFactory.Create()));
        }
    }
}