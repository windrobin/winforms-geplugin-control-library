&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;



https://sites.google.com/site/earthapi2/GEWebBrowser.JPG

# Introduction #

The main control that holds the Google Earth Plugin. All other controls in the library interact with the plugin object hosted in this control.

Key features

  * Load the plugin from a hosted page or from an embeded file in the library
  * Get the current plugin view as a Bitmap
  * Load Kml or Kmz files into the plugin
  * Inject and invoke Javascript at runtime
  * Add and remove API event listeners

# Details #

The GEWebBrowser inherits from the standard [System.Windows.Forms.WebBrowser](http://msdn.microsoft.com/en-us/library/system.windows.forms.webbrowser.aspx) control class and has the same base members, methods, properties and events.

The GEWebBrowser control cannot be used by partially trusted code. For more information, see [Using Libraries from Partially Trusted Code](http://msdn.microsoft.com/en-us/library/8skskf63.aspx)

## Public Events ##

[PluginReady](ExampleForm.md)

```
/// <summary>
/// Raised when the plugin is ready
/// </summary>
public event EventHandler<GEEventArgs> PluginReady;
```

[KmlEvent](AddEventListener.md)

```
/// <summary>
/// Raised when there is a kmlEvent
/// </summary>
public event EventHandler<GEEventArgs> KmlEvent;
```

[KmlLoaded](KmlLoaded.md)

```
/// <summary>
/// Raised when a kml/kmz file has loaded
/// </summary>
public event EventHandler<GEEventArgs> KmlLoaded;
```

[ScriptError](ScriptError.md)

```
/// <summary>
/// Raised when there is a script error in the document 
/// </summary>
public event EventHandler<GEEventArgs> ScriptError;
```

[PluginEvent](AddEventListener.md)

```
/// <summary>
/// Rasied when there is a GEPlugin event
/// </summary>
public event EventHandler<GEEventArgs> PluginEvent;
```

[ViewEvent](AddEventListener.md)

```
/// <summary>
/// Rasied when there is a viewchangebegin, viewchange or viewchangeend event 
/// </summary>
public event EventHandler<GEEventArgs> ViewEvent;
```

## Public Properties ##

[Plugin](Plugin.md)

```
/// <summary>
/// Gets the plugin instance associated with the control
/// </summary>
public dynamic Plugin
```

[ImageyBase](ImageyBase.md)

```
/// <summary>
/// Gets or sets the current imagery base for the plug-in
/// </summary>
public ImageryBase ImageyBase
```

[PluginIsReady](PluginIsReady.md)

```
/// <summary>
/// Gets a value indicating whether the plug-in is ready
/// </summary>
public bool PluginIsReady
```

[RedirectLinksToSystemBrowser](RedirectLinksToSystemBrowser.md)

```
/// <summary>
/// Gets or sets a value indicating whether to redirect html links to the system browser
/// Default is true, setting this false opens links inside the GEWebBrowser control.
/// </summary>
public bool RedirectLinksToSystemBrowser
```

## Public Methods ##

[AddEventListener](AddEventListener.md)

```
/// <summary>
/// Wrapper for the the google.earth.addEventListener method
/// </summary>
/// <param name="feature">The target feature</param>
/// <param name="action">The event Id</param>
/// <param name="javascript">The name of javascript callback function to use, or an anonymous function</param>
/// <param name="useCapture">Optionally use event capture</param>
/// <example>GEWebBrowser.AddEventListener(object, "click", "someFunction");</example>
/// <example>GEWebBrowser.AddEventListener(object, "click", "function(event){alert(event.getType);}");</example>
public void AddEventListener(dynamic feature, EventId action, string javascript = null, bool useCapture = false)
```

[CreateInstance](CreateInstance.md)

```
/// <summary>
/// Wrapper for the google.earth.createInstance method
/// See: http://code.google.com/apis/earth/documentation/reference/google_earth_namespace.html#70288485024d8129dd1c290fb2e5553b
/// </summary>
/// <param name="database">The database name</param>
/// <example>GEWebBrowser.CreateInstance(ImageryBase.Moon);</example>
public void CreateInstance(ImageryBase database)
```

[ExecuteBatch](ExecuteBatch.md)

```
/// <summary>
/// Wrapper for the google.earth.executeBatch method
/// See: http://code.google.com/apis/earth/documentation/reference/google_earth_namespace.html#b26414915202d39cad12bcd5bd99e739
/// Efficiently executes an arbitrary, user-defined function (the batch function),minimizing
/// the amount of overhead incurred during cross-process communication between the browser
/// and Google Earth Plugin. 
/// </summary>
public void ExecuteBatch()
```

[FetchKml](FetchKml.md)

```
/// <summary>
/// Load a remote kml/kmz file 
/// This function requires a 'twin' LoadKml function in javascript
/// this twin function will call "google.earth.fetchKml"
/// </summary>
/// <param name="url">string path to a kml reasource</param>
/// <example>GEWebBrowser.FetchKml("http://www.site.com/file.kml");</example>
public void FetchKml(string url)
```

[FetchKml](FetchKml.md)

```
/// <summary>
/// Load a remote kml/kmz file 
/// This function requires a 'twin' LoadKml function in javascript
/// this twin function will call "google.earth.fetchKml"
/// </summary>
/// <param name="url">Uri to a kml reasource</param>
/// <example>GEWebBrowser.FetchKml("http://www.site.com/file.kml");</example>
public void FetchKml(Uri url)
```

[FetchKml](FetchKml.md)

```
/// <summary>
/// Load a remote kml/kmz file 
/// This function requires a 'twin' LoadKml function in javascript
/// this twin function will call "google.earth.fetchKml"
/// </summary>
/// <param name="url">path to a kml/kmz file</param>
/// <param name="completionCallback">name of javascript callback function to call after fetching completes</param>
/// <example>GEWebBrowser.FetchKml("http://www.site.com/file.kml", "createCallback_(OnKmlLoaded)");</example>
public void FetchKml(string url, string completionCallback)
```

[FetchKmlSynchronous](FetchKmlSynchronous.md)

```
/// <summary>
/// Same as FetchKml but returns the IKmlObject
/// </summary>
/// <param name="url">path to a kml/kmz file</param>
/// <param name="timeout">time to wait for return in ms</param>
/// <returns>The kml as a kmlObject</returns>
/// <example>GEWebBrowser.FetchKmlSynchronous("http://www.site.com/file.kml");</example>
public object FetchKmlSynchronous(string url, int timeout = 1000)
```

[FetchKmlLocal](FetchKmlLocal.md)

```
/// <summary>
/// Loads a local kml file 
/// </summary>
/// <param name="path">path to a local kml file</param>
/// <example>GWEebBrower.FetchKml("C:\file.kml");</example>
public void FetchKmlLocal(string path)
```

[ParseKml](ParseKml.md)

```
/// <summary>
/// GEPlugin.parseKml() wrapper
/// Parses a kml string and loads it into the plugin
/// </summary>
/// <param name="kml">kml string to process</param>
public void ParseKml(string kml)
```

[ParseKmlObject](ParseKmlObject.md)

```
/// <summary>
/// Parses a KmlObject  and loads it into the plugin.
/// </summary>
/// <param name="kml">kml object to process</param>
public void ParseKmlObject(dynamic kml)
```

[InvokeDoGeocode](InvokeDoGeocode.md)

```
/// <summary>
/// Invokes the javascript function 'doGeocode'
/// Automatically flys to the location if one is found
/// </summary>
/// <param name="input">the location to geocode</param>
/// <returns>the point object (if any)</returns>
/// <example>GEWebBrowser.InvokeDoGeocode("London");</example>
public object InvokeDoGeocode(string input)
```

[InjectJavascript](InjectJavascript.md)

```
/// <summary>
/// Inject a javascript element into the document head
/// </summary>
/// <param name="javascript">the script code</param>
/// <example>GEWebBrowser.InjectJavascript("var say=function(msg){alert(msg);}");</example>
public void InjectJavascript(string javascript)
```

[InvokeJavascript](InvokeJavascript.md)

```
/// <summary>
/// Executes a script function defined in the currently loaded document. 
/// </summary>
/// <param name="function">The name of the function to invoke</param>
/// <returns>The result of the evaluated function</returns>
/// <example>GEWebBrowser.InvokeJavascript("say");</example>
public object InvokeJavascript(string function)
```

[InvokeJavascript](InvokeJavascript.md)

```
/// <summary>
/// Executes a script function that is defined in the currently loaded document. 
/// </summary>
/// <param name="function">The name of the function to invoke</param>
/// <param name="args">any arguments</param>
/// <returns>The result of the evaluated function</returns>
/// <example>GEWebBrowser.InvokeJavascript("say", new object[] { "hello" });</example>
public object InvokeJavascript(string function, object[] args)
```

[InvokeJavascript](InvokeJavascript.md)

```
/// <summary>
/// Kills all running geplugin processes on the system
/// </summary>
public void KillAllPluginProcesses()
```

[LoadEmbededPlugin](LoadEmbededPlugin.md)

```
/// <summary>
/// Load the embeded html document into the browser 
/// </summary>
public void LoadEmbededPlugin()
```

[RemoveEventListener](RemoveEventListener.md)

```
/// <summary>
/// Wrapper for the the google.earth.removeEventListener method
/// </summary>
/// <param name="feature">The target feature</param>
/// <param name="action">The event Id</param>
/// <param name="useCapture">Optional, use event capture</param>
public void RemoveEventListener(object feature, EventId action, bool useCapture = false)
```

[ScreenGrab](ScreenGrab.md)

```
/// <summary>
/// Take a 'screen grab' of the current GEWebBrowser view
/// </summary>
/// <returns>bitmap image</returns>
public Bitmap ScreenGrab()
```

[SetLanguage](SetLanguage.md)

```
/// <summary>
/// Set the plugin langauge
/// </summary>
/// <param name="code">The language code to use</param>
public void SetLanguage(string code)
```

[Refresh](Refresh.md)

```
/// <summary>
/// Reloads the document currently displayed in the control
/// Overides the default WebBrowser Refresh method
/// </summary>
public override void Refresh()
```
## Source ##

[GEWebBrowser.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/GEWebBrowser.cs)

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;