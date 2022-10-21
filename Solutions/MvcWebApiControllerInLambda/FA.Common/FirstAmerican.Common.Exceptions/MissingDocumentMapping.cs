using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    [Serializable]
    public class MissingDocumentMapping : FirstAmericanException
    {
        public MissingDocumentMapping()
        {
        }

        public MissingDocumentMapping(string message) : base(message)
        {
        }

        public MissingDocumentMapping(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MissingDocumentMapping(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}