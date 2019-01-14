using System;
using System.IO;

namespace DynamicForms.Web.Infrastructure.ApplicationConfigurations
{
    public class BasePathConfiguration : ApplicationConfigurationBase
    {
        public override void Configure()
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}