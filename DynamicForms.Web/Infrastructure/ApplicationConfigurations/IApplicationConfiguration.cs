namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public interface IApplicationConfiguration
    {
        void Configure();

        bool IsEnabled { get; }
    }
}