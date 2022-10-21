using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class DocumentDataStreamMismatch : FirstAmericanException
    {
        public DocumentDataStreamMismatch()
        {
        }

        public DocumentDataStreamMismatch(string message) : base(message)
        {
        }

        public DocumentDataStreamMismatch(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DocumentDataStreamMismatch(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}