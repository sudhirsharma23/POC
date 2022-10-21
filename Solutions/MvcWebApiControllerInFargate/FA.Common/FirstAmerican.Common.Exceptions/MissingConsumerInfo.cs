using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingConsumerInfo : FirstAmericanException
    {
        public MissingConsumerInfo()
        {
        }

        public MissingConsumerInfo(string message) : base(message)
        {
        }

        public MissingConsumerInfo(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingConsumerInfo(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}