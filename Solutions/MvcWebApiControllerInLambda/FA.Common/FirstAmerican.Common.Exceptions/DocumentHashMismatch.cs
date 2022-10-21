using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class DocumentHashMismatch : FirstAmericanException
    {
        public DocumentHashMismatch()
        {
        }

        public DocumentHashMismatch(string message) : base(message)
        {
        }

        public DocumentHashMismatch(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DocumentHashMismatch(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}