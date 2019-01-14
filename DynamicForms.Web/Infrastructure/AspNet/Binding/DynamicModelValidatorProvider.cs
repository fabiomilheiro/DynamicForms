using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Common.Models.ConfigurationModels.Validation;
using DynamicForms.Web.Infrastructure.ApplicationFormCogs.Validation;

namespace DynamicForms.Web.Infrastructure.AspNet.Binding
{
    public class DynamicModelValidatorProvider : DataAnnotationsModelValidatorProvider
    {
        private readonly DynamicValidationAttribute dynamicValidationAttribute;

        public DynamicModelValidatorProvider(DynamicValidationAttribute dynamicValidationAttribute)
        {
            this.dynamicValidationAttribute = dynamicValidationAttribute;
        }

        protected override IEnumerable<ModelValidator> GetValidators(ModelMetadata metadata, ControllerContext context, IEnumerable<Attribute> attributes)
        {
            if (metadata.PropertyName == "Value" && typeof(FieldBase).IsAssignableFrom(metadata.ContainerType))
            {
                attributes = attributes.Union(new[] { dynamicValidationAttribute });
            }

            return base.GetValidators(metadata, context, attributes);
        }
    }
}