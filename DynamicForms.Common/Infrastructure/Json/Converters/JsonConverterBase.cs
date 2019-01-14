using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using DynamicForms.Common.Infrastructure.Helpers;
using DynamicForms.Common.Infrastructure.Json.Attributes;

namespace DynamicForms.Common.Infrastructure.Json.Converters
{
    public abstract class JsonConverterBase<T> : JsonConverter
    {
        private readonly IRequestWrapper requestWrapper;

        public JsonConverterBase(IRequestWrapper requestWrapper)
        {
            this.requestWrapper = requestWrapper;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            var source = JObject.Load(reader);
            var target = Create(objectType, source);

            using (var newReader = CopyReaderForObject(source.CreateReader(), source))
            {
                serializer.Populate(newReader, target);
                OnConverted(newReader, target);
            }

            return target;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (ReferenceEquals(value, null))
            {
                writer.WriteNull();
                return;
            }

            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(value.GetType());

            writer.WriteStartObject();

            foreach (var jsonProperty in contract.Properties)
            {
                var propertyName = jsonProperty.PropertyName;
                var propertyValue = jsonProperty.ValueProvider.GetValue(value);

                if (ShouldSkip(jsonProperty, value, propertyName, propertyValue))
                {
                    continue;
                }

                writer.WritePropertyName(propertyName);
                if (jsonProperty.Converter != null && jsonProperty.Converter.CanWrite)
                {
                    jsonProperty.Converter.WriteJson(writer, propertyValue, serializer);
                }
                else
                {
                    serializer.Serialize(writer, propertyValue);
                }
            }

            writer.WriteEndObject();
        }

        private static bool IsNullAndShouldIgnoreNull(JsonProperty property, object propertyValue)
        {
            return propertyValue == null && property.NullValueHandling == NullValueHandling.Ignore;
        }

        private bool ShouldSkip(JsonProperty jsonProperty, object value, string propertyName, object propertyValue)
        {
            if (jsonProperty.Ignored)
            {
                return true;
            };

            if (!ShouldSerialize(jsonProperty, value))
            {
                return true;
            }

            if (IsNullAndShouldIgnoreNull(jsonProperty, propertyValue))
            {
                return true;
            }

            if (ShouldSkipPresentationProperty(jsonProperty))
            {
                return true;
            }

            return false;
        }

        private bool ShouldSkipPresentationProperty(JsonProperty jsonProperty)
        {
            var isPresentationProperty = jsonProperty.DeclaringType.GetProperty(jsonProperty.UnderlyingName)
                .GetCustomAttributes<PresentationAttribute>()
                .Any();

            return isPresentationProperty && requestWrapper.RetrieveClientType() == ClientType.Partner;
        }

        private static bool ShouldSerialize(JsonProperty property, object instance)
        {
            return property.ShouldSerialize == null || property.ShouldSerialize(instance);
        }

        public virtual T Create(Type objectType, JObject source)
        {
            return (T)Activator.CreateInstance(objectType);
        }

        internal virtual void OnConverted(JsonReader jsonReader, T target)
        {
        }

        private static JsonReader CopyReaderForObject(JsonReader reader, JObject source)
        {

            var jsonReader = source.CreateReader();
            jsonReader.Culture = reader.Culture;
            jsonReader.DateFormatString = reader.DateFormatString;
            jsonReader.DateParseHandling = reader.DateParseHandling;
            jsonReader.DateTimeZoneHandling = reader.DateTimeZoneHandling;
            jsonReader.FloatParseHandling = reader.FloatParseHandling;
            jsonReader.MaxDepth = reader.MaxDepth;
            jsonReader.SupportMultipleContent = reader.SupportMultipleContent;

            return jsonReader;
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }
    }
}