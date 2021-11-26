using System;
using System.Runtime.Serialization;

namespace PimVIII.Services
{
    [Serializable]
    internal class IntegrityException : Exception
    {
        public IntegrityException()
        {
        }

        public IntegrityException(string message) : base(message)
        {
        }

        public IntegrityException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IntegrityException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}