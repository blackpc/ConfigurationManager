using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Configuration.Internal
{
    interface IConfigurationFileReader
    {
        ConfigurationSection[] Read(string fileName);
    }
}
