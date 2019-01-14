using DynamicForms.Web.Infrastructure.Caching;

namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public class FormPreloadingApplicationConfiguration : ApplicationConfigurationBase
    {
        private readonly IFormLoadStarter formLoadStarter;

        public FormPreloadingApplicationConfiguration(IFormLoadStarter formLoadStarter)
        {
            this.formLoadStarter = formLoadStarter;
        }

        public override void Configure()
        {
            formLoadStarter.Start();
        }

        public override bool IsEnabled { get; } = true;
    }
}