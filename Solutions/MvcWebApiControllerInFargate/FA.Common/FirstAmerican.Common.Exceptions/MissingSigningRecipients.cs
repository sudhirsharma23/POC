using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingSigningRecipients : FirstAmericanException
    {
        public MissingSigningRecipients()
        {
        }

        public MissingSigningRecipients(string message) : base(message)
        {
        }

        public MissingSigningRecipients(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingSigningRecipients(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}