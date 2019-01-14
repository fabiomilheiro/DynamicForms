using System.Web.Mvc;
using Microsoft.Practices.Unity;
using DynamicForms.Web.Infrastructure.AspNet.Binding;

namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public class ModelMetadataProviderApplicationConfiguration : ApplicationConfigurationBase
    {
        private readonly IUnityContainer container;

        public ModelMetadataProviderApplicationConfiguration(IUnityContainer container)
        {
            this.container = container;
        }
        public override void Configure()
        {
            ModelMetadataProviders.Current = new DynamicModelMetadataProvider(container);
        }
    }
}