using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    /// <summary>
    /// This exception is thrown when Fast file id is 0 or less than 0.
    /// </summary>
    [Serializable]
    public class InvalidFastFileIdException : FirstAmericanException
    {
        public InvalidFastFileIdException()
        {
        }

        public InvalidFastFileIdException(string message) : base(message)
        {
        }

        public InvalidFastFileIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidFastFileIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}