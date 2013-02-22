using Configuration.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Internal
{
    class ConfigurationSection
    {
        /// <summary>
        /// Gets section name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets properties of section
        /// </summary>
        public Dictionary<string, object> Properties { get; private set; }

        public ConfigurationSection(string sectionName)
        {
            this.Name = sectionName;
            this.Properties = new Dictionary<string, object>();
        }

        public void AddProperty(string name, object value)
        {
            if (this.Properties.ContainsKey(name))
                throw new DuplicatePropertyNameException(name, this.Name);

            this.Properties.Add(name, value);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Section \"{0}\"{1}", this.Name, Environment.NewLine);

            foreach (var property in this.Properties)
                sb.AppendFormat("   {0} = {1}{2}", property.Key, property.Value, Environment.NewLine);

            return sb.ToString();
        }
    }
}
