using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingSigningEnvelope : FirstAmericanException
    {
        public MissingSigningEnvelope()
        {
        }

        public MissingSigningEnvelope(string message) : base(message)
        {
        }

        public MissingSigningEnvelope(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingSigningEnvelope(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}