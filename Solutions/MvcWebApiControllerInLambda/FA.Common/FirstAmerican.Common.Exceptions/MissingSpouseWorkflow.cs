using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingSpouseWorkflow : FirstAmericanException
    {
        public MissingSpouseWorkflow()
        {
        }

        public MissingSpouseWorkflow(string message) : base(message)
        {
        }

        public MissingSpouseWorkflow(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingSpouseWorkflow(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}