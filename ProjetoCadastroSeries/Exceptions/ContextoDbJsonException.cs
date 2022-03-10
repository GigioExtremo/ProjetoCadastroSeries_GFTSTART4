using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastroSeries.Exceptions
{
    internal class ContextoDbJsonException : Exception
    {
        public ContextoDbJsonException()
        {
        }

        public ContextoDbJsonException(string message) : base(message)
        {
        }

        public ContextoDbJsonException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContextoDbJsonException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
