using AutoMapper;
using Microsoft.Practices.Unity;
using DynamicForms.Web.Infrastructure.Mappings;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class AutoMapperDependencyRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            var configuration = new MapperConfiguration(c =>
            {
                c.AddProfile<ConfigurationModelsProfile>();
            });

            var mapper = configuration.CreateMapper();

            container.RegisterInstance(mapper);
        }
    }
}