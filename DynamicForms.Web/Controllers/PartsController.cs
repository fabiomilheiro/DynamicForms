using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Web.Infrastructure.Repositories;
using DynamicForms.Web.Models.Parts;

namespace DynamicForms.Web.Controllers
{
    public class PartsController : ApplicationFormController
    {
        private readonly IRequestWrapper requestWrapper;
        private readonly IConfigurationRepository configurationRepository;

        public PartsController(IRequestWrapper requestWrapper, IConfigurationRepository configurationRepository)
        {
            this.requestWrapper = requestWrapper;
            this.configurationRepository = configurationRepository;
        }

        [OutputCache(Duration = 3600)]
        public ActionResult TopMenu()
        {
            var viewModel = new TopMenuViewModel
            {
                Configurations = GetGroupedConfigurations()
            };

            return PartialView(viewModel);
        }

        private Dictionary<string, List<FormConfiguration>> GetGroupedConfigurations()
        {
            var configurations = configurationRepository.RetrieveConfigurations();

            var groupedConfigurations = new Dictionary<string, List<FormConfiguration>>();

            foreach (var configuration in configurations)
            {
                if (!groupedConfigurations.ContainsKey(configuration.Group.ID))
                {
                    groupedConfigurations[configuration.Group.ID] = new List<FormConfiguration>();
                }

                groupedConfigurations[configuration.Group.ID].Add(configuration);
            }

            return groupedConfigurations;
        }

        public ActionResult Buttons()
        {
            var viewModel = new ButtonsViewModel();
            var stepNumber = requestWrapper.RetrieveCurrentStepNumber();

            if (stepNumber == 0)
            {
                return null;
            }

            if (stepNumber > 1)
            {
                viewModel.Left = new ButtonViewModel
                {
                    ActionType = ButtonActionType.Previous,
                    Text = "Previous"
                };
            }

            if (stepNumber < ApplicationFormContext.Configuration.Experiences[0].Navigation.Steps.Count)
            {
                viewModel.Right = new ButtonViewModel
                {
                    ActionType = ButtonActionType.Next,
                    Text = "Next"
                };

                return PartialView(viewModel);
            }


            viewModel.Right = new ButtonViewModel
            {
                ActionType = ButtonActionType.Submit,
                Text = "Submit"
            };

            return PartialView(viewModel);
        }
    }
}