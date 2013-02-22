ConfigurationManager
====================

Provides a comfortable way to read configurations file into a custom class

Usage
====================
  1. Create class which will be filled with data from configurations file:
```csharp
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
```
  2. Create configurations file (e.g. app.cfg):
<pre>
[Server]
Name  = Http proxy host // You can add some comments
Ip		= 192.168.137.128 
Port	= 8080
Version	= 1.1
</pre>  
  3. Load configurations file:
<pre>
    ConfigurationManager.Load("Application", "app.cfg");
</pre>
  4. Get configurations:
<pre>
    ServerConfiguration config = ConfigurationManager.GetClass<ServerConfiguration>("Application");
</pre>
  5. Now you can access to the values from configurations file via the properties of your class:
<pre>
    ConsoleWrite(config.Name);
    ConsoleWrite(config.Ip);
    ConsoleWrite(config.Port);
    ConsoleWrite(config.ProtocolVersion);
</pre>







