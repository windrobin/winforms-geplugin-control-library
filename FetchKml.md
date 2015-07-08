

# Introduction #

This is a wrapper for the google.earth.fetchKml method. It is used to load a kml/kmz file into the plug-in.

# Details #

Because it is not possible to work directly with the members of the [google.earth namespace](http://code.google.com/apis/earth/documentation/reference/google_earth_namespace.html) in managed code a pair of wrapper functions are required; one in javascript and one in managed code. The overloaded functions listed here are used to initiated the loading of kml data.

A url, and optionally a callback function, are passed to the method.
The method invokes the plugin to begin to load the resource specified.
Once the kml data has been loaded by the plugin, the callback function is called and with the deserialized kml object data being passed as a parameter.

If no callback function has been specified then generic event handling is used.

For more information on the google.earth.fetchKml method please see: http://code.google.com/apis/earth/documentation/reference/google_earth_namespace.html#afca518f43d5f863b254c5fa23a5967f2

## Overload List ##

```
public void FetchKml(
    string Uri
)

public void FetchKml(
    Uri url
)

public void FetchKml(
    string url,
    string completionCallback
)
```


## Examples ##

This example loads the remote file 'placemarks.kml' in geWebBrowser1.

```
geWebBrowser1.FetchKml("http://www.site.com/placemarks.kml");
```

This example loads the remote file 'model.kmk' in geWebBrowser1.

```
geWebBrowser1.FetchKml("http://www.site.com/model.kmz");
```


## Remarks ##

This method should only be used once the plug-in has been loaded in the GEWebBrowser for it to have any meaning. Also, this method requires that the holding page has a function call jsFetchKml defined in it. The function in the embedded page is set up for this.

To add/display the actual data you have fetched to either GEWebBrowser or KmlTreeView you would use the [KmlLoaded](KmlLoaded.md) event for within the [GEWebBrowser](GEWebBrowser.md).

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;