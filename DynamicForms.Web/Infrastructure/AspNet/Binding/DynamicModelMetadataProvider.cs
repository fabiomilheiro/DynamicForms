using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Web.Infrastructure.AspNet.Binding
{
    public class DynamicModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        private readonly IUnityContainer container;

        public DynamicModelMetadataProvider(IUnityContainer container)
        {
            this.container = container;
        }

        protected override ModelMetadata CreateMetadata(IEnumerable<Attribute> attributes, Type containerType,
            Func<object> modelAccessor, Type modelType, string propertyName)
        {
            var attributesList = attributes.ToList();

            attributesList.ForEach(a => container.BuildUp(a));

            return base.CreateMetadata(attributesList, containerType, modelAccessor, modelType, propertyName);
        }
    }
}