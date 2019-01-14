using System.Web.Http;

namespace DynamicForms.DataApi.Infrastructure.ApplicationConfigurations
{
    public interface IApplicationConfiguration
    {
        void Configure(HttpConfiguration configuration);
    }
}