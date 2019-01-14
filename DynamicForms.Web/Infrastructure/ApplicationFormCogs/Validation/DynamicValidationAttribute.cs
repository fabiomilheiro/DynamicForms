using System;
using System.ComponentModel.DataAnnotations;
using DynamicForms.Common.Infrastructure.Extensions;
using Microsoft.Practices.Unity;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Common.Models.ConfigurationModels.Validation;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Forms;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Mapping;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Validation
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Class)]
    public class DynamicValidationAttribute : ValidationAttribute
    {
        [Dependency]
        public IPropertyValueRetriever PropertyValueRetriever { get; set; }

        [Dependency]
        public ApplicationFormContextService ApplicationFormContextService { get; set; }

        [Dependency]
        public FieldMapperFactory FieldMapperFactory { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var field = validationContext.ObjectInstance as FieldBase;

            if (field == null)
            {
                throw new InvalidOperationException($"You may use '{this.GetType()}' only inside of a model that is of a type that inherits '{typeof(FieldBase)}'.");
            }

            var applicationFormContext = ApplicationFormContextService.RetrieveApplicationFormContext();

            foreach (var validator in field.Validators)
            {
                var result = validator.Validate(
                            PropertyValueRetriever.RetrievePropertyValue<object>(field, "Value"),
                            new FieldValidationContext
                            {
                                Configuration = applicationFormContext.Configuration,
                                Application = applicationFormContext.Application,
                                PreviousApplicationState = applicationFormContext.PreviousApplicationState,
                                Field = field
                            });

                if (result != null)
                {
                    return new ValidationResult(result.ErrorMessage);
                }
            }

            return null;
        }
    }
}