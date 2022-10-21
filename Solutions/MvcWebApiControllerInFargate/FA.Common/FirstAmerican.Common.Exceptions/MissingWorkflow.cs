using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingWorkflow : FirstAmericanException
    {
        public MissingWorkflow()
        {
        }

        public MissingWorkflow(string message) : base(message)
        {
        }

        public MissingWorkflow(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingWorkflow(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}