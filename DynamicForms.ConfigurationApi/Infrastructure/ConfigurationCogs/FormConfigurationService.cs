using System.Collections.Generic;
using System.Linq;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.ConfigurationApi.Repository;

namespace DynamicForms.ConfigurationApi.Infrastructure.ConfigurationCogs
{
    public interface IFormConfigurationService
    {
        FormConfiguration RetrieveConfiguration(string id);

        FormConfiguration RetrieveConfiguration(string id, int versionID);
        List<FormConfiguration> RetrieveConfigurations();
    }

    public class FormConfigurationService : IFormConfigurationService
    {
        private readonly IFormConfigurationRepository configurationRepository;
        private readonly IRequestWrapper requestWrapper;

        public FormConfigurationService(IFormConfigurationRepository configurationRepository, IRequestWrapper requestWrapper)
        {
            this.configurationRepository = configurationRepository;
            this.requestWrapper = requestWrapper;
        }

        public FormConfiguration RetrieveConfiguration(string id)
        {
            return configurationRepository.RetrieveConfiguration(id);
        }

        public FormConfiguration RetrieveConfiguration(string id, int versionID)
        {
            return configurationRepository.RetrieveConfiguration(id, versionID);
        }

        public List<FormConfiguration> RetrieveConfigurations()
        {
            return configurationRepository.RetrieveConfigurations();
        }
    }
}