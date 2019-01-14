using System.Web.Mvc;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Web.Infrastructure.AspNet.Binding;

namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public class ModelBinderApplicationConfiguration : ApplicationConfigurationBase
    {
        private readonly StepModelBinder stepModelBinder;
        private readonly FieldModelBinder fieldModelBinder;

        public ModelBinderApplicationConfiguration(StepModelBinder stepModelBinder, FieldModelBinder fieldModelBinder)
        {
            this.stepModelBinder = stepModelBinder;
            this.fieldModelBinder = fieldModelBinder;
        }
        
        public override void Configure()
        {
            //ModelBinders.Binders.Add(typeof(Step), stepModelBinder);
            ModelBinders.Binders.Add(typeof(FieldBase), fieldModelBinder);
        }
    }
}