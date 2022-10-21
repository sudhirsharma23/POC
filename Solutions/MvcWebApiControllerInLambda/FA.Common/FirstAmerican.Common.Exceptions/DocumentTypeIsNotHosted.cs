using System;
using System.Runtime.Serialization;

namespace FirstAmerican.Common.Exceptions
{
    /// <summary>
    /// Exception thrown when a document is not a recognized hosted type.
    /// </summary>
    [Serializable]
    public class DocumentTypeIsNotHosted : FirstAmericanException
    {
        public DocumentTypeIsNotHosted()
        {
        }

        public DocumentTypeIsNotHosted(string message) : base(message)
        {
        }

        public DocumentTypeIsNotHosted(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DocumentTypeIsNotHosted(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}