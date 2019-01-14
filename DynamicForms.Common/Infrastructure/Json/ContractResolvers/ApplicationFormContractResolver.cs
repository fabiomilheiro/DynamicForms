using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using DynamicForms.Common.Infrastructure.Json.Converters;
using DynamicForms.Common.Models;
using DynamicForms.Common.Models.ConfigurationModels;
using DynamicForms.Common.Models.ConfigurationModels.Blocks;
using DynamicForms.Common.Models.ConfigurationModels.FieldAnnotations;
using DynamicForms.Common.Models.ConfigurationModels.Fields;
using DynamicForms.Common.Models.ConfigurationModels.Validation;

namespace DynamicForms.Common.Infrastructure.Json.ContractResolvers
{
    public class ApplicationFormContractResolver : CamelCasePropertyNamesContractResolver
    {
        private readonly Dictionary<Type, JsonConverter> typeConverterMappings;

        public ApplicationFormContractResolver(
            ConfigurationConverter configurationConverter,
            FieldConverter fieldConverter,
            ValidatorConverter validatorConverter,
            FieldAnnotationConverter fieldAnnotationConverter,
            BlockConverter blockConverter)
        {
            typeConverterMappings = new Dictionary<Type, JsonConverter>
            {
                { typeof(FormConfiguration), configurationConverter },
                { typeof(FieldBase), fieldConverter },
                { typeof(ValidatorBase), validatorConverter },
                { typeof(FieldAnnotationBase), fieldAnnotationConverter},
                { typeof(BlockBase), blockConverter}
            };
        }

        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            var mapping = typeConverterMappings.SingleOrDefault(kvp => kvp.Key.IsAssignableFrom(objectType));
            if (!mapping.Equals(default(KeyValuePair<Type, JsonConverter>)))
            {
                return mapping.Value;
            }

            return base.ResolveContractConverter(objectType);
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);



            return property;
        }
    }
}