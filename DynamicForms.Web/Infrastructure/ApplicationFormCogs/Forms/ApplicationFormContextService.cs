using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ApplicationModels;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Web.Infrastructure.Repositories;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms
{
    public interface IApplicationFormContextService
    {
        ApplicationFormContext RetrieveApplicationFormContext();
    }

    public class ApplicationFormContextService : IApplicationFormContextService
    {
        private readonly IRequestWrapper requestWrapper;
        private readonly IConfigurationRepository configurationRepository;
        private readonly IApplicationRepository applicationRepository;

        public ApplicationFormContextService(IRequestWrapper requestWrapper, IConfigurationRepository configurationRepository, IApplicationRepository applicationRepository)
        {
            this.requestWrapper = requestWrapper;
            this.configurationRepository = configurationRepository;
            this.applicationRepository = applicationRepository;
        }

        public ApplicationFormContext RetrieveApplicationFormContext()
        {
            var result = requestWrapper.RetrieveItems()["ApplicationFormContext"] as ApplicationFormContext;

            if (result == null)
            {
                var formID = requestWrapper.RetrieveApplicationFormID();
                if (string.IsNullOrEmpty(formID))
                {
                    return new ApplicationFormContext
                    {
                        Configuration = new FormConfiguration(),
                        Application = new Application(),
                        PreviousApplicationState = new Application()
                    };
                }

                result = new ApplicationFormContext
                {
                    Configuration = RetrieveConfiguration(formID),
                    Application = GetApplication()
                };

                result.PreviousApplicationState = result.Application.Clone();

                requestWrapper.RetrieveItems()["ApplicationFormContext"] = result;
            }

            return result;
        }

        private Application GetApplication()
        {
            var retrieveApplicationId = requestWrapper.RetrieveApplicationId();
            if (string.IsNullOrEmpty(retrieveApplicationId))
            {
                return new Application();
            }

            return applicationRepository.RetrieveApplication(retrieveApplicationId);
        }

        private FormConfiguration RetrieveConfiguration(string formID)
        {
            var versionID = requestWrapper.RetrieveApplicationFormVersionID();

            if (versionID.HasValue)
            {
                return configurationRepository.RetrieveConfiguration(formID, versionID.Value);
            }

            return configurationRepository.RetrieveConfiguration(formID);
        }
    }
}