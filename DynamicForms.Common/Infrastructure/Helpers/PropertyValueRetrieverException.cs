using System;
using System.Runtime.Serialization;

namespace DynamicForms.Common.Infrastructure.Helpers
{
    [Serializable]
    public class PropertyValueRetrieverException : Exception
    {
        public PropertyValueRetrieverException()
        {
        }

        public PropertyValueRetrieverException(string message)
            : base(message)
        {
        }

        public PropertyValueRetrieverException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected PropertyValueRetrieverException(SerializationInfo serializationInfo, StreamingContext streamContext)
            : base(serializationInfo, streamContext)
        {
        }
    }
}