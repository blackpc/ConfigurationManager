using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Configuration.Exceptions
{
    [Serializable]
    public class TargetPropertyNotFoundException : Exception
    {
        public TargetPropertyNotFoundException(Type targetType, PropertyInfo property)
            : base(string.Format("Target property '{0}' not exists in class '{1}'", property.Name, targetType.Name)) { }

        public TargetPropertyNotFoundException(string message) : base(message) { }
        public TargetPropertyNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected TargetPropertyNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
