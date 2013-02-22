using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Exceptions
{
    [Serializable]
    public class ConfigurationSetNotExistsException : Exception
    {
        public ConfigurationSetNotExistsException(string setName)
            : base(string.Format("Configuration set '{0}' not found", setName)){ }
        public ConfigurationSetNotExistsException(string message, Exception inner) : base(message, inner) { }
        protected ConfigurationSetNotExistsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
