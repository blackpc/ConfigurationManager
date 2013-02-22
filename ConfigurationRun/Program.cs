using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Configuration;

namespace ConfigurationRun
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigurationManager.Load("test", @"TestFile\TestConf.cfg");
            
            var target = ConfigurationManager.GetValue<bool>("test", "TestConfig", "ConfField1");

            Console.WriteLine(target);
        }
    }
}
