using Configuration.Attributes;

namespace ConfigurationTest.Input
{
	[ConfigurationSection("Server")]
    class ServerConfiguration
    {
		[ConfigurationProperty]
        public string Name { get; set; }

		[ConfigurationProperty]
        public string Ip { get; set; }

		[ConfigurationProperty]
        public int Port { get; set; }

		[ConfigurationProperty("Version")]
        public float ProtocolVersion { get; set; }
    }
}
