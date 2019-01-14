using Microsoft.Practices.Unity;
using DynamicForms.Common.Models.ConfigurationModels.Validation;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Validation;
using DynamicForms.Web.Infrastructure.AspNet.Binding;

namespace DynamicForms.Web.Infrastructure.DependencyRegistrations
{
    public class ValidationMetadataRegistrations : IDependencyRegistrations
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<DynamicModelValidatorProvider>(new ContainerControlledLifetimeManager());
            container.RegisterType<DynamicValidationAttribute>(new ContainerControlledLifetimeManager());
        }
    }
}