using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingDocument : FirstAmericanException
    {
        public MissingDocument()
        {
        }

        public MissingDocument(string message) : base(message)
        {
        }

        public MissingDocument(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingDocument(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}