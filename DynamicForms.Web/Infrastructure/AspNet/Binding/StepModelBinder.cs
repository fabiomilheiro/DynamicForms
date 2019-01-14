using System;
using System.Web.Mvc;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;

namespace DynamicForms.Web.Infrastructure.AspNet.Binding
{
    public class StepModelBinder : DefaultModelBinder
    {
        private readonly IApplicationFormContextService applicationFormContextService;
        private readonly IRequestWrapper requestWrapper;

        public StepModelBinder(IApplicationFormContextService applicationFormContextService, IRequestWrapper requestWrapper)
        {
            this.applicationFormContextService = applicationFormContextService;
            this.requestWrapper = requestWrapper;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var viewModel = GetCurrentStep();
            var viewModelType = viewModel.GetType();
            //var viewModelBindingContext = CreateViewModelBindingContext(bindingContext, viewModel, viewModelType);

            return Binders.GetBinder(viewModelType).BindModel(controllerContext, bindingContext);
        }

        private Step GetCurrentStep()
        {
            var applicationFormContext = applicationFormContextService.RetrieveApplicationFormContext();

            return applicationFormContext.Configuration.Experiences[0].Navigation.Steps[requestWrapper.RetrieveCurrentStepNumber() - 1];
        }

        private static ModelBindingContext CreateViewModelBindingContext(ModelBindingContext bindingContext, object viewModel, Type viewModelType)
        {
            return new ModelBindingContext
            {
                ModelMetadata = CreateModelMetadata(viewModel, viewModelType),
                ModelName = bindingContext.ModelName,
                ModelState = bindingContext.ModelState,
                ValueProvider = bindingContext.ValueProvider
            };
        }

        private static ModelMetadata CreateModelMetadata(object viewModel, Type viewModelType)
        {
            return ModelMetadataProviders.Current.GetMetadataForType(() => viewModel, viewModelType);
        }
    }
}