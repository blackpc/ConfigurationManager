using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Exceptions
{
    [Serializable]
    public class NoConfigurationClassException : Exception
    {
        public NoConfigurationClassException(Type targetType) 
            : base("ConfigurationClass attribute not set for class " + targetType.Name) { }

        public NoConfigurationClassException(string message) : base(message) { }
        public NoConfigurationClassException(string message, Exception inner) : base(message, inner) { }
        protected NoConfigurationClassException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
