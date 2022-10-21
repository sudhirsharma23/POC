using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingConsumerFile : FirstAmericanException
    {
        public MissingConsumerFile()
        {
        }

        public MissingConsumerFile(string message) : base(message)
        {
        }

        public MissingConsumerFile(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingConsumerFile(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}