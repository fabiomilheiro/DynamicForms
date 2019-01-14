using System;
using Newtonsoft.Json.Serialization;

namespace DynamicForms.Common.Infrastructure.Json
{
    public class ApplicationFormSerializationBinder : DefaultSerializationBinder
    {
        public override void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            base.BindToName(serializedType, out assemblyName, out typeName);
        }

        public override Type BindToType(string assemblyName, string typeName)
        {
            return base.BindToType(assemblyName, typeName);
        }
    }
}