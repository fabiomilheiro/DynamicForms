using System;
using Newtonsoft.Json;

namespace DynamicForms.Common.Models.ConfigurationModels.Validation
{
    public abstract class ValidatorBase
    {
        [JsonProperty(Order = -3)]
        public string Type => GetType().Name.Replace("Validator", null);

        [JsonProperty(Order = -2)]
        public abstract string Description { get; }

        public abstract FieldValidationResult Validate(object value, FieldValidationContext context);

        public override string ToString()
        {
            return Description;
        }
    }

    public abstract class ValidatorBase<TValue> : ValidatorBase
    {
        public override FieldValidationResult Validate(object value, FieldValidationContext context)
        {
            if (!string.IsNullOrEmpty(value as string))
            {
                return ValidateIfSpecified((TValue) value, context);
            }

            return Validate((TValue)value, context);
        }

        internal virtual FieldValidationResult Validate(TValue value, FieldValidationContext context)
        {
            return null;
        }

        internal virtual FieldValidationResult ValidateIfSpecified(TValue value, FieldValidationContext context)
        {
            return null;
        }
    }
}