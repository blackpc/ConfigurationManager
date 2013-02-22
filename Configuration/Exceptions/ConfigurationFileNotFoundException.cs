using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Exceptions
{
    [Serializable]
    public class ConfigurationFileNotFoundException : Exception
    {
        public ConfigurationFileNotFoundException(string fileName): this(fileName, null) { }
        public ConfigurationFileNotFoundException(string fileName, Exception inner) 
            : base(string.Format("Configuration file '{0}' not found", fileName), inner) { }
        protected ConfigurationFileNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
