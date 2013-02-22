using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Exceptions
{
    [Serializable]
    public class NoConfigurationPropertyException : Exception
    {
        public NoConfigurationPropertyException(Type targetType, PropertyInfo property)
            : base(string.Format("ConfigurationProperty attribute not set for property '{0}' in class '{1}'", property.Name, targetType.Name)) { }
        public NoConfigurationPropertyException(string message) : base(message) { }
        public NoConfigurationPropertyException(string message, Exception inner) : base(message, inner) { }
        protected NoConfigurationPropertyException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
