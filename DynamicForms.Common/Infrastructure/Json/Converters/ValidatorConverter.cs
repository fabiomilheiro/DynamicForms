using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using DynamicForms.Common.Infrastructure.Extensions;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Infrastructure.Json.Converters
{
    public class ValidatorConverter : JsonConverterBase<ValidatorBase>
    {
        private static readonly List<Type> validators = GetWidgetTypes();

        public ValidatorConverter(IRequestWrapper requestWrapper) : base(requestWrapper)
        {
        }

        private static List<Type> GetWidgetTypes()
        {
            return typeof(ValidatorBase)
                .Assembly
                .GetTypes()
                .Where(t => typeof(ValidatorBase).IsAssignableFrom(t) && t.IsConcreteClass())
                .ToList();
        }

        public override ValidatorBase Create(Type objectType, JObject source)
        {
            var validatorTypeName = source["type"] + "Validator";
            var validatorType = validators.SingleOrDefault(w => w.Name == validatorTypeName);
            if (validatorType == null)
            {
                throw new NotSupportedException(
                    $"There is no validator named '{validatorTypeName}'. Be sure to suffix the validator class with 'Validator'.");
            }

            return (ValidatorBase)Activator.CreateInstance(validatorType);
        }
    }
}