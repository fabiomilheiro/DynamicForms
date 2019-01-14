using System.Collections.Generic;
using System.Web.Http;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.ConfigurationApi.Infrastructure.ConfigurationCogs;

namespace DynamicForms.ConfigurationApi.Controllers
{
    public class FormController : ApiController
    {
        private readonly IFormConfigurationService configurationService;

        public FormController(IFormConfigurationService configurationService)
        {
            this.configurationService = configurationService;
        }

        public List<FormConfiguration> Get()
        {
            return configurationService.RetrieveConfigurations();
        }

        public FormConfiguration Get(string id)
        {
            return configurationService.RetrieveConfiguration(id);
        }

        [Route("~/Form/{id}/{versionID}")]
        public FormConfiguration Get(string id, int versionID)
        {
            return configurationService.RetrieveConfiguration(id, versionID);
        }
    }
}