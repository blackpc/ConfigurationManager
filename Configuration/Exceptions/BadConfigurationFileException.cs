using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Exceptions
{
    [Serializable]
    public class BadConfigurationFileException : Exception
    {
        public BadConfigurationFileException() { }
        public BadConfigurationFileException(string message) : base(message) { }
        public BadConfigurationFileException(string message, Exception inner) : base(message, inner) { }
        protected BadConfigurationFileException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
