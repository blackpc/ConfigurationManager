using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ConfigurationSectionAttribute : Attribute
    {
        public String ClassName { get; set; }

        public ConfigurationSectionAttribute()
        {
            ClassName = string.Empty;
        }

        public ConfigurationSectionAttribute(string className)
        {
            this.ClassName = className;
        }
    }
}
