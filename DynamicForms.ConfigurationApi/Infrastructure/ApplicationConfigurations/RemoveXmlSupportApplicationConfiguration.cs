using System.Linq;
using System.Web.Http;

namespace DynamicForms.ConfigurationApi.Infrastructure.ApplicationConfigurations
{
    public class RemoveXmlSupportApplicationConfiguration : IApplicationConfiguration
    {
        public void Configure(HttpConfiguration configuration)
        {
            var xmlMediaType = configuration.Formatters.XmlFormatter.SupportedMediaTypes.Single(t => t.MediaType == "application/xml");
            configuration.Formatters.XmlFormatter.SupportedMediaTypes.Remove(xmlMediaType);
        }
    }
}