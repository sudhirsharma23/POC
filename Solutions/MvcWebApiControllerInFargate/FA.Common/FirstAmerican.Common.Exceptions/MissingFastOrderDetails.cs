using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingFastOrderDetails : FirstAmericanException
    {
        public MissingFastOrderDetails()
        {
        }

        public MissingFastOrderDetails(string message) : base(message)
        {
        }

        public MissingFastOrderDetails(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingFastOrderDetails(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
