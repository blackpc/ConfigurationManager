using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Exceptions
{
    [Serializable]
    public class PropertyTypeMismatchException : Exception
    {

        public PropertyTypeMismatchException(string setName, string sectionName, string propertyName, Type sourceType, Type targetType)
            : base(string.Format(
                "Property type mismatch, can't convert '{0}' to '{1}' [" +
                "Set = '{2}', Section = '{3}', Property = '{4}']", 
                sourceType.Name, 
                targetType.Name,
                setName,
                sectionName,
                propertyName)) { }

        public PropertyTypeMismatchException(string message) : base(message) { }
        public PropertyTypeMismatchException(string message, Exception inner) : base(message, inner) { }
        protected PropertyTypeMismatchException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
