using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoCadastroSeries.Exceptions
{
    internal class JsonDBAccessException : Exception
    {
        public JsonDBAccessException()
        {
        }

        public JsonDBAccessException(string message) : base(message)
        {
        }

        public JsonDBAccessException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected JsonDBAccessException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
