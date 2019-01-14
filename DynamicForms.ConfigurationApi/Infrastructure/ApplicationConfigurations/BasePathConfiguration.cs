using System;
using System.IO;
using System.Web.Http;

namespace DynamicForms.ConfigurationApi.Infrastructure.ApplicationConfigurations
{
    public class BasePathConfiguration : IApplicationConfiguration
    {
        public void Configure(HttpConfiguration configuration)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}