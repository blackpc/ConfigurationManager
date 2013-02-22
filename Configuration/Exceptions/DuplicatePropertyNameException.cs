using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Exceptions
{
    [Serializable]
    public class DuplicatePropertyNameException : Exception
    {
        public DuplicatePropertyNameException(string propertyName,  string sectionName)
            : base(string.Format("Duplicate property '{0}' in section '{1}",propertyName, sectionName)){ }
        public DuplicatePropertyNameException(string message) : base(message) { }
        public DuplicatePropertyNameException(string message, Exception inner) : base(message, inner) { }
        protected DuplicatePropertyNameException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
