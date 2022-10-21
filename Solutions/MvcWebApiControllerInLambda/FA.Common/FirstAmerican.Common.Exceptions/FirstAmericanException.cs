using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    /// <summary>
    /// A generic Exception, relevant to First American business logic.
    /// </summary>
    [Serializable]
    public class FirstAmericanException : Exception
    {
        public FirstAmericanException()
        {
        }

        public FirstAmericanException(string message) : base(message)
        {
        }

        public FirstAmericanException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FirstAmericanException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}