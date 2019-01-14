using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;

namespace DynamicForms.Common.Infrastructure.Json
{
    public class VariantJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        private readonly IJsonSerializerSettingsFactory jsonSerializerSettingsFactory;

        public VariantJsonMediaTypeFormatter(IJsonSerializerSettingsFactory jsonSerializerSettingsFactory)
        {
            this.jsonSerializerSettingsFactory = jsonSerializerSettingsFactory;
        }

        public override MediaTypeFormatter GetPerRequestFormatterInstance(Type type, HttpRequestMessage request,
            MediaTypeHeaderValue mediaType)
        {
            var formatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = jsonSerializerSettingsFactory.Create()
            };

            return formatter;
        }
    }
}