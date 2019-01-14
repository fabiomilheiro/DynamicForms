using System;
using System.Web.Mvc;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Fields;

namespace DynamicForms.Web.Infrastructure.AspNet.Binding
{
    public class FieldModelBinder : DefaultModelBinder
    {
        private readonly IFieldFactory fieldFactory;

        public FieldModelBinder(IFieldFactory fieldFactory)
        {
            this.fieldFactory = fieldFactory;
        }

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var viewModel = CreateViewModel(bindingContext);
            var viewModelType = viewModel.GetType();
            var viewModelBindingContext = CreateViewModelBindingContext(bindingContext, viewModel, viewModelType);
            
            var binder = Binders.GetBinder(viewModelType);
            var result = binder.BindModel(controllerContext, viewModelBindingContext);
            return result;
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

        private object CreateViewModel(ModelBindingContext bindingContext)
        {
            var fieldType = bindingContext.ValueProvider.GetValue(GetFieldTypeKey(bindingContext)).AttemptedValue;

            return fieldFactory.Create(fieldType);
        }

        private static string GetFieldTypeKey(ModelBindingContext bindingContext)
        {
            return $"{bindingContext.ModelName}.Type";
        }
    }
}