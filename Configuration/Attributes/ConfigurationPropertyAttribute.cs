using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Attributes
{
    [AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class ConfigurationPropertyAttribute: Attribute
    {
        public string FieldName { get; set; }

        public ConfigurationPropertyAttribute()
        {
            this.FieldName = string.Empty;
        }

        public ConfigurationPropertyAttribute(string fieldName)
        {
            this.FieldName = fieldName;
        }
    }
}
