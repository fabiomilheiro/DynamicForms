using System.Web.Mvc;
using DynamicForms.Web.Infrastructure.AspNet.Binding;

namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public class DynamicModelValidatorProviderApplicationConfiguration : ApplicationConfigurationBase
    {
        private readonly DynamicModelValidatorProvider dynamicModelValidatorProvider;

        public DynamicModelValidatorProviderApplicationConfiguration(DynamicModelValidatorProvider dynamicModelValidatorProvider)
        {
            this.dynamicModelValidatorProvider = dynamicModelValidatorProvider;
        }

        public override void Configure()
        {
            ModelValidatorProviders.Providers.Clear();
            ModelValidatorProviders.Providers.Add(dynamicModelValidatorProvider);
        }
    }
}