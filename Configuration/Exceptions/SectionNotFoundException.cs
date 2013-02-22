using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Exceptions
{
    [Serializable]
    public class SectionNotFoundException : Exception
    {
        public SectionNotFoundException(string sectionName, string setName)
            : base(string.Format("Section '{0}' in configuration set '{1}' not found", sectionName, setName)) { }
        public SectionNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected SectionNotFoundException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
