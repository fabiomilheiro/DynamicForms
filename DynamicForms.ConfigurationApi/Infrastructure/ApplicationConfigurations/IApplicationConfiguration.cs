using System.Web.Http;

namespace DynamicForms.ConfigurationApi.Infrastructure.ApplicationConfigurations
{
    public interface IApplicationConfiguration
    {
        void Configure(HttpConfiguration configuration);
    }
}