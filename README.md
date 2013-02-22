## ConfigurationManager

Provides a comfortable way to read configurations file into a custom class

### Usage
<hr />
  1. Create a class which will be filled with data from configurations file:
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
  2. Create configurations file (in our case "app.cfg"):
<pre>
[Server]
Name      = Http proxy host
Ip		  = 192.168.137.128 // You can add some comments
Port	  = 8080
Version	  = 1.1
</pre>  
  3. Load configurations file:
```csharp
    ConfigurationManager.Load("Application", "app.cfg");
```
  4. Get configurations:
```csharp
    ServerConfiguration config = ConfigurationManager.GetClass<ServerConfiguration>("Application");
```
  5. Now you can access to the values from configurations file via the properties of your class:
```csharp
    Console.WriteLine(config.Name);
    Console.WriteLine(config.Ip);
    Console.WriteLine(config.Port);
    Console.WriteLine(config.ProtocolVersion);
```

### License
License: [The MIT License (MIT)](http://www.opensource.org/licenses/mit-license.php)





