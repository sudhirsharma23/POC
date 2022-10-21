using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    /// <summary>
    /// A generic Exception, relevant to First American business logic.
    /// </summary>
    [Serializable]
    public class MissingOrderInformation : FirstAmericanException
    {
        public MissingOrderInformation()
        {
        }

        public MissingOrderInformation(string message) : base(message)
        {
        }

        public MissingOrderInformation(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingOrderInformation(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
