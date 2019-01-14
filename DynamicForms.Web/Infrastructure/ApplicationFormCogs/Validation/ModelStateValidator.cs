using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Web.Infrastructure.ApplicationFormCogs.Validation
{
    public interface IModelStateValidator
    {        
        IEnumerable<ModelStateValidationResult> Validate(object model, string prefix);
    }


    public class ModelStateValidator : IModelStateValidator
    {
        private readonly DynamicValidationAttribute dynamicValidationAttribute;

        public ModelStateValidator(DynamicValidationAttribute dynamicValidationAttribute)
        {
            this.dynamicValidationAttribute = dynamicValidationAttribute;
        }

        public IEnumerable<ModelStateValidationResult> Validate(object model, string prefix)
        {
            var validationResults = new List<ModelStateValidationResult>();

            ValidateRecursively(validationResults, model, prefix, null);

            return validationResults;
        }

        private static bool IsCollectionOfSimpleTypes(Type type)
        {
            if (type.IsArray && IsSimpleType(type.GetElementType()))
            {
                return true;
            }

            return type.IsGenericType
                   && IsGenericCollection(type)
                   && IsSimpleType(type.GetGenericArguments()[0]);
        }

        private static bool IsGenericCollection(Type type)
        {
            return type.GetGenericTypeDefinition() == typeof(IEnumerable<>)
                || type.GetGenericTypeDefinition() == typeof(IList<>)
                || type.GetGenericTypeDefinition() == typeof(List<>);
        }

        private static bool IsSimpleType(Type type)
        {
            return type.IsValueType || type == typeof(string);
        }

        private static IEnumerable<ModelStateValidationResult> GetObjectValidationResult(object model, string prefix, string propertyName)
        {
            if (model == null)
            {
                return new List<ModelStateValidationResult>();
            }

            var validationContext = new ValidationContext(model);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(model, validationContext, validationResults);

            return GetModelStateValidationResults(prefix, propertyName, validationResults);
        }

        private IEnumerable<ModelStateValidationResult> GetPropertyValidationResult(object container,
            object model, string propertyName, string prefix)
        {
            var validationContext = new ValidationContext(container)
            {
                MemberName = propertyName
            };

            var validationResults = new List<ValidationResult>();
            
            Validator.TryValidateProperty(model, validationContext, validationResults);

            if (container is FieldBase && propertyName == "Value")
            {
                Validator.TryValidateValue(model, validationContext, validationResults,
                    new[] {dynamicValidationAttribute});
            }
            else
            {
                Validator.TryValidateValue(model, validationContext, validationResults,
                    new ValidationAttribute[] {});
            }

            return GetModelStateValidationResults(prefix, propertyName, validationResults);
        }

        private static IEnumerable<ModelStateValidationResult> GetModelStateValidationResults(string prefix, string propertyName, List<ValidationResult> validationResults)
        {
            foreach (var validationResult in validationResults)
            {
                if (validationResult.MemberNames.Any())
                {
                    foreach (var memberName in validationResult.MemberNames)
                    {
                        yield return new ModelStateValidationResult
                        {
                            Key = CreateModelStateValidationResultKey(prefix, memberName),
                            ErrorMessage = validationResult.ErrorMessage
                        };
                    }
                }
                else
                {
                    yield return new ModelStateValidationResult
                    {
                        Key = CreateModelStateValidationResultKey(prefix, propertyName),
                        ErrorMessage = validationResult.ErrorMessage
                    };
                }
            }
        }

        private static string CreateModelStateValidationResultKey(string prefix, string memberName)
        {
            if (!string.IsNullOrEmpty(memberName))
            {
                return string.Format(CultureInfo.InvariantCulture, "{0}.{1}", prefix, memberName);
            }

            return prefix;
        }

        private void ValidateRecursively(List<ModelStateValidationResult> validationResults, object model, string prefix, string propertyName)
        {
            if (model == null)
            {
                return;
            }

            validationResults.AddRange(GetObjectValidationResult(model, prefix, propertyName));

            foreach (var property in model.GetType().GetProperties())
            {
                var propertyPrefix = string.Format(CultureInfo.InvariantCulture, "{0}.{1}", prefix, property.Name);

                validationResults.AddRange(GetPropertyValidationResult(model, property.GetValue(model), property.Name, prefix));

                if (property.PropertyType.IsValueType || property.PropertyType == typeof(string))
                {
                    continue;
                }

                if (typeof(IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    if (!IsCollectionOfSimpleTypes(property.PropertyType))
                    {
                        var collection = (IEnumerable) property.GetValue(model);

                        if (collection != null)
                        {
                            var index = 0;

                            foreach (var item in collection)
                            {
                                var positionPrefix = string.Format(CultureInfo.InvariantCulture, "{0}[{1}]",
                                    propertyPrefix, index);
                                ValidateRecursively(validationResults, item, positionPrefix, null);
                                index++;
                            }
                        }
                    }
                }
                else
                {
                    ValidateRecursively(validationResults, property.GetValue(model), propertyPrefix, property.Name);
                }
            }
        }
    }
}