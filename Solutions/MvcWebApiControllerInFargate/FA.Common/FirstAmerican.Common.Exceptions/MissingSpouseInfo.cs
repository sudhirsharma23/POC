using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    public class MissingSpouseInfo : FirstAmericanException
    {
        public MissingSpouseInfo()
        {
        }

        public MissingSpouseInfo(string message) : base(message)
        {
        }

        public MissingSpouseInfo(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingSpouseInfo(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}