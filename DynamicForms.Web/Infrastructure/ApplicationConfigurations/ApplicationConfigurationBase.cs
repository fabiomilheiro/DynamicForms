namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public abstract class ApplicationConfigurationBase : IApplicationConfiguration
    {
        public abstract void Configure();

        public virtual bool IsEnabled { get; } = true;
    }
}