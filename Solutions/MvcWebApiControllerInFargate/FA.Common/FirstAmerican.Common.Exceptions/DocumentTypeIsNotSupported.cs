using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class DocumentTypeIsNotSupported : FirstAmericanException
    {
        public DocumentTypeIsNotSupported()
        {
        }

        public DocumentTypeIsNotSupported(string message) : base(message)
        {
        }

        public DocumentTypeIsNotSupported(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DocumentTypeIsNotSupported(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}