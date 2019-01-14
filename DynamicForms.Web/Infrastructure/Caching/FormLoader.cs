using System;
using System.Net.Http;
using Microsoft.Ajax.Utilities;
using DynamicForms.Web.Infrastructure.Logging;
using DynamicForms.Web.Infrastructure.Repositories;

namespace DynamicForms.Web.Infrastructure.Caching
{
    public interface IFormLoader
    {
        void PreloadAllFormSteps();
    }

    public class FormLoader : IFormLoader
    {
        private readonly IConfigurationRepository configurationRepository;
        private readonly IApplicationSettings applicationSettings;

        public FormLoader(IConfigurationRepository configurationRepository, IApplicationSettings applicationSettings)
        {
            this.configurationRepository = configurationRepository;
            this.applicationSettings = applicationSettings;
        }

        public void PreloadAllFormSteps()
        {
            var formConfigurations = configurationRepository.RetrieveConfigurations();

            foreach (var formConfiguration in formConfigurations)
            {
                Logger.Current.LogDebug<FormLoader>($"Loading the form (Form ID: {formConfiguration.Group.ID}, Version ID: {formConfiguration.VersionID})...");
                LoadUrl($"{applicationSettings.BaseUrl}Form/{formConfiguration.Group.ID}");

                foreach (var step in formConfiguration.Experiences[0].Navigation.Steps)
                {
                    LoadUrl($"{applicationSettings.BaseUrl}Step/{formConfiguration.Group.ID}/{formConfiguration.VersionID}/{step.Number}");
                }

                Logger.Current.LogDebug<FormLoader>("Finished.");
            }
        }

        private void LoadUrl(string url)
        {
            using (var client = new HttpClient())
            {
                client.GetStringAsync(url).Wait(TimeSpan.FromSeconds(5));
            }
        }
    }
}