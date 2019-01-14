using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Json;
using DynamicForms.Common.Models;
using DynamicForms.Common.Models.ConfigurationModels;

namespace DynamicForms.ConfigurationApi.Repository
{
    public interface IFormConfigurationRepository
    {
        FormConfiguration RetrieveConfiguration(string id);

        FormConfiguration RetrieveConfiguration(string id, int versionId);
        List<FormConfiguration> RetrieveConfigurations();
    }

    public class FormConfigurationRepository : IFormConfigurationRepository
    {
        private readonly IJsonSerializerSettingsFactory jsonSerializerSettingsFactory;

        public FormConfigurationRepository(IJsonSerializerSettingsFactory jsonSerializerSettingsFactory)
        {
            this.jsonSerializerSettingsFactory = jsonSerializerSettingsFactory;
        }


        public FormConfiguration RetrieveConfiguration(string id)
        {
            var group = GetConfigurationGroup(id);
            var configuration = GetConfiguration(id, group.ActiveVersionID);
            configuration.Group = group;
            return configuration;
        }

        public FormConfiguration RetrieveConfiguration(string id, int versionID)
        {
            var configuration = GetConfiguration(id, versionID);
            configuration.Group = GetConfigurationGroup(id);
            return configuration;
        }

        public List<FormConfiguration> RetrieveConfigurations()
        {
            var configurations = new List<FormConfiguration>();

            var formConfigurationIDs = Directory.EnumerateDirectories("App_Data").Select(Path.GetFileName).ToList();

            foreach (var formConfigurationID in formConfigurationIDs)
            {
                var versionIDs = Directory.EnumerateFiles($"App_Data/{formConfigurationID}/Versions/");

                foreach (var versionID in versionIDs.Select(v => Path.GetFileNameWithoutExtension(v).ToInteger()))
                {
                    configurations.Add(RetrieveConfiguration(formConfigurationID, versionID));
                }
            }

            return configurations;
        }

        private FormConfiguration GetConfiguration(string id, int versionID)
        {
            return JsonConvert.DeserializeObject<FormConfiguration>(
                File.ReadAllText($"App_Data/{id}/Versions/{versionID}.json"), jsonSerializerSettingsFactory.Create());
        }

        private FormConfigurationGroup GetConfigurationGroup(string id)
        {
            return JsonConvert.DeserializeObject<FormConfigurationGroup>(
                File.ReadAllText($"App_Data/{id}/ConfigurationGroup.json"), jsonSerializerSettingsFactory.Create());
        }
    }
}