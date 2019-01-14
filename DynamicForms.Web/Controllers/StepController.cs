using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DynamicForms.Common.Models.ApplicationModels;
using Newtonsoft.Json;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.ApplicationTransitions;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Validation;
using DynamicForms.Web.Infrastructure.Helpers;
using DynamicForms.Web.Infrastructure.Repositories;
using DynamicForms.Web.Models.Pages;
using DynamicForms.Web.Models.Parts;

namespace DynamicForms.Web.Controllers
{
    public class StepController : ApplicationFormController
    {
        private readonly IModelStateValidator modelStateValidator;
        private readonly IMerger merger;
        private readonly IFieldMappingOrchestrator fieldMappingOrchestrator;
        private readonly IApplicationRepository applicationRepository;
        private readonly ISubmitApplicationTransition submitApplicationTransition;

        public StepController(
            IModelStateValidator modelStateValidator,
            IMerger merger,
            IFieldMappingOrchestrator fieldMappingOrchestrator,
            IApplicationRepository applicationRepository,
            ISubmitApplicationTransition submitApplicationTransition)
        {
            this.modelStateValidator = modelStateValidator;
            this.merger = merger;
            this.fieldMappingOrchestrator = fieldMappingOrchestrator;
            this.applicationRepository = applicationRepository;
            this.submitApplicationTransition = submitApplicationTransition;
        }

        [Route("~/Step/{formID:alpha}/{versionID:int}/{stepNumber:int}")]
        public ActionResult Index(int stepNumber)
        {
            return View(new StepViewModel
            {
                Step = GetStepFilled(stepNumber)
            });
        }

        [HttpPost]
        [Route("~/Step/{formID:alpha}/{versionID:int}/{stepNumber:int}")]
        public ActionResult Index(StepViewModel viewModel, string formID, int versionID, int stepNumber)
        {
            MergeConfigurationToStepViewModel(viewModel, stepNumber);
            MapToApplication(viewModel.Step);
            Validate(viewModel);

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            SaveApplication(viewModel);

            if (viewModel.ActionType == ButtonActionType.Next)
            {
                return RedirectToAction("Index", new { formID, versionID, stepNumber = stepNumber + 1, id = ApplicationFormContext.Application.ID });
            }

            if (viewModel.ActionType == ButtonActionType.Previous)
            {
                return RedirectToAction("Index", new { formID, versionID, stepNumber = stepNumber - 1, id = ApplicationFormContext.Application.ID });
            }

            return RedirectToAction("ThankYou", new { formID, versionID, id = ApplicationFormContext.Application.ID });
        }

        private void SaveApplication(StepViewModel viewModel)
        {
            if (viewModel.ActionType == ButtonActionType.Submit)
            {
                this.submitApplicationTransition.Execute(ApplicationFormContext);
            }

            applicationRepository.SaveApplication(ApplicationFormContext.Application);
        }

        private void MapToApplication(Step step)
        {
            var fields = step.Sections.SelectMany(s => s.Fields).ToArray();

            this.fieldMappingOrchestrator.MapToApplication(ApplicationFormContext.Application, fields);
        }

        private Step GetStepFilled(int stepNumber)
        {
            var step = GetStep(stepNumber);
            var fields = step.Sections.SelectMany(s => s.Fields).ToArray();

            this.fieldMappingOrchestrator.MapToFields(ApplicationFormContext.Application, fields);

            return step;
        }

        private Step GetStep(int stepNumber)
        {
            return ApplicationFormContext.Configuration.Experiences[0].Navigation.Steps[stepNumber - 1];
        }

        [Route("~/ThankYou/{formID:alpha}/{versionID:int}")]
        public ActionResult ThankYou()
        {
            var scoringResult = this.ApplicationFormContext.Application.ScoringResult;

            var thankYouViewModel = new ThankYouViewModel
            {
                ScoringResult = scoringResult,
                ScoringSentence = ScoringSentencesByOutcome[scoringResult.Outcome]
            };

            return View(thankYouViewModel);
        }

        private static readonly Dictionary<ScoringOutcome, string> ScoringSentencesByOutcome = new Dictionary<ScoringOutcome, string>
        {
            { ScoringOutcome.Pass, "Your account will be created." },
            { ScoringOutcome.Warning, "You must agree that you understand the risks." },
            { ScoringOutcome.Reject, "Unfortunately, we can't open an account for you as don't have the necessary requirements." }
        };

        private void Validate(StepViewModel viewModel)
        {
            // TODO: Move this into a validation orchestrator.
            var validationResults = new List<ModelStateValidationResult>();

            // TODO: Test: Confirm validation is run.
            //for (var i = 0; i < viewModel.Step.Sections.Count; i++)
            //{
            //    validationResults.AddRange(modelStateValidator.Validate(viewModel.Step.Sections[i], string.Format(CultureInfo.InvariantCulture, "Step.Sections[{0}]", i)));
            //}

            validationResults.AddRange(modelStateValidator.Validate(viewModel.Step, "Step"));


            ModelState.Clear();

            foreach (var validationResult in validationResults)
            {
                ModelState.AddModelError(validationResult.Key, validationResult.ErrorMessage);
            }
        }

        private void MergeConfigurationToStepViewModel(StepViewModel viewModel, int stepNumber)
        {
            var currentStepConfiguration = ApplicationFormContext.Configuration.Experiences[0].Navigation.Steps[stepNumber - 1];

            merger.Merge(currentStepConfiguration, viewModel.Step);
        }
    }
}