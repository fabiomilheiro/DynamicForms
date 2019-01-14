using System.Configuration;

namespace DynamicForms.Web.Infrastructure
{
    public interface IApplicationSettings
    {
        string ConfigurationApiUrl { get; }

        string DataApiUrl { get; }

        string BaseUrl { get; }

        bool EnableCache { get; }
    }
    public class ApplicationSettings : IApplicationSettings
    {
        public string ConfigurationApiUrl => ConfigurationManager.AppSettings["ConfigurationApiUrl"];

        public string DataApiUrl => ConfigurationManager.AppSettings["DataApiUrl"];

        public string BaseUrl => ConfigurationManager.AppSettings["BaseUrl"];

        public bool EnableCache => bool.Parse(ConfigurationManager.AppSettings["EnableCache"]);
    }
}