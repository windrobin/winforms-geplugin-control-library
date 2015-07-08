&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;



# Introduction #

The GEServer class can be used to serve files over a standard HTTP connection.

# Details #

This class provide a basic web server for the Plug-in to work with. A local server provides a way to circumvent all access issues between JavaScript and the local file system by serving the local files over a standard HTTP connection.

The server itself supports a limited number of file / Content-types (MIME types), these are;

  * txt text/plain
  * htm text/html
  * kml application/vnd.google-earth.kml+xml
  * kmz application/vnd.google-earth.kmz
  * jpg image/jpeg
  * png image/png
  * gif image/gif
  * dae model/vnd.collada+xml

The server uses version 1.1 of HTTP.

By default the server only accepts connections from GoogleEarth User-agents on the same machine.

With the default settings the application start up folder is the virtual root directory and can be accessed via the loopback address or the localhost alias.

  * http://127.0.0.1:8080/
  * http://locahost:8080/

## Constructors ##

[Server](usingTheServer.md)
```
/// <summary>
/// Initializes a new instance of the GEServer class
/// </summary>
public GEServer() 
```

[Server](usingTheServer.md)
```
/// <summary>
/// Initializes a new instance of the GEServer class
/// </summary>
/// <param name="rootDirectory">The server root directory</param>
public GEServer(string rootDirectory)
```

[Server](usingTheServer.md)
```
/// <summary>
/// Initializes a new instance of the GEServer class
/// </summary>
/// <param name="rootDirectory">The server root directory</param>
/// <param name="defaultFileName">Default file name to use</param>
public Server(string rootDirectory, string defaultFileName)
```

## Public Properties ##

[DefaultFileName](usingTheServer.md)
```
/// <summary>
/// Gets or sets the default file name 
/// The default value is "default.kml"
/// </summary>
public string DefaultFileName
```

[IPAddress](usingTheServer.md)
```
/// <summary>
/// Gets or sets the IP Address for the server to use 
/// The default is 127.0.0.1 (localhost/loopback)
/// </summary>
public IPAddress IPAddress
```

[RootDirectory](usingTheServer.md)
```
/// <summary>
/// Gets or sets the root server directory (webroot) 
/// http://localhost:port/ will point to this directory
/// </summary>
public string RootDirectory
```

[Port](usingTheServer.md)
```
/// <summary>
/// Gets or sets a value indicating the port for the server to use
/// </summary>
public int Port
```

## Public methods ##

[Start](usingTheServer.md)
```
/// <summary>
/// Starts the server
/// </summary>
public void Start()
```

[Stop](usingTheServer.md)
```
/// <summary>
/// Stops the server
/// </summary>
public void Stop()
```

## Source ##

http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/HttpServer/GEServer.cs