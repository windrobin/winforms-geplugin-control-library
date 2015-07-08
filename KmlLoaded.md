

# Introduction #

the KmlLoaded event is raised when ever data has been loaded via the FetchKml method.

# Details #

The actual kmlObject that represents the loaded data is accessible via the GEEventArgs.ApiObject property.

## Syntax ##

```
public event EventHandler<GEEventArgs> KmlLoaded;
```

## Examples ##

This example presumes you have an empty form, onto which you have dragged an instance of the GEWebBrowser control and the KmlTreeView control.

The code loads the remote file 'placemarks.kml' into geWebBrowser1.
It then uses the KmlLoaded event to display the data in the geWebBrowser1 and kmlTreeview1.

```
public Form1()
{
  InitializeComponent();

  // load the plugin
  geWebBrowser1.LoadEmbededPlugin();

  // when the plug-in has loaded
  geWebBrowser1.PluginReady += (o, e) =>
  {
      // load the kml from the local server
      geWebBrowser1.FetchKml("http://localhost/placemarks.kml");
  };

  // when the kml has loaded
  geWebBrowser1.KmlLoaded += (o, e) =>
  {
      // add the kml to the browser and treeview
      geWebBrowser1.ParseKmlObject(e.ApiObject);
      kmlTreeview1.ParseKmlObject(e.ApiObject);
  };
}
```

## Remarks ##

This method should only be used once the plug-in has been loaded in the GEWebBrowser for it to have any meaning. Here this is ensured by making the call from within the PluginReady event handler.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;