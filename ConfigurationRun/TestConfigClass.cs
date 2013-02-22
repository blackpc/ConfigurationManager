using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration.Attributes;

namespace ConfigurationRun
{
    [ConfigurationSection("TestConfig")]
    class TestConfigClass
    {
        [ConfigurationProperty]
        public double ConfField1 { get; set; }

        [ConfigurationProperty]
        public string ConfField2 { get; set; }

        [ConfigurationProperty]
        public bool ConfField3 { get; set; }

        [ConfigurationProperty]
        public int ConfField4 { get; set; }

        public override string ToString()
        {
            return string.Format("F1 = {0}\nF2 = {1}\nF3 = {2}\nF4 = {3}", this.ConfField1, this.ConfField2, this.ConfField3, this.ConfField4);
        }
    }
}
