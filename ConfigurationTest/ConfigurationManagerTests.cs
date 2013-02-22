using System;
using System.Linq;
using Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Configuration.Exceptions;
using ConfigurationTest.Input;

namespace ConfigurationTest
{
    [TestClass]
    public class ConfigurationManagerTests
    {
        Random _randomizer = new Random();

        [TestInitialize]
        public void Init()
        {
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

        [TestMethod]
        [DeploymentItem(@"Input\\Application.cfg")]
        public void LoadTest()
        {
            ConfigurationManager.Load("Application", "Application.cfg");
            var configClass = ConfigurationManager.GetClass<ServerConfiguration>("Application");
            
            Assert.IsNotNull(configClass);

            Assert.AreEqual<string>(configClass.Ip, "192.168.137.128");
            Assert.AreEqual<string>(configClass.Name, "Http proxy host");
            Assert.AreEqual<int>(configClass.Port, 8080);
            Assert.AreEqual<float>(configClass.ProtocolVersion, 1.1f);
        }

        [TestMethod]
        [ExpectedException(typeof(ConfigurationFileNotFoundException))]
        public void ConfigurationFileNotFoundTest()
        {
            ConfigurationManager.Load(
                "NotExisting" + _randomizer.Next(1000000, 9999999).ToString(), 
                "NotExistingConfigurationFile" + _randomizer.Next(1000000, 9999999).ToString() + ".cfg");
        }
    }
}
