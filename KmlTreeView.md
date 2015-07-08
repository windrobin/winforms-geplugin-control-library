&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;



![https://sites.google.com/site/earthapi2/KmlTreeView2.jpg](https://sites.google.com/site/earthapi2/KmlTreeView2.jpg)

# Introduction #

The KMLTreeView control intergtes with the GEWebBrowser to display kml/kmz files in a standard tree structure.

# Example #

This example presumes you have an instance of the GEWebBrowser and KmlTreeView on a Form. It shows how to load and display the same KML data in KmlTreeView and plug-in.

```
public partial class Form1 : Form
{
  public Form1()
  {
    InitializeComponent();
    
    // load the plugin
    this.geWebBrowser1.LoadEmbeddedPlugin();
    
    // set up the events we need, plugin ready and kml loaded
    this.geWebBrowser1.PluginReady += this.geWebBrowser1_PluginReady;
    this.geWebBrowser1.KmlLoaded += this.geWebBrowser1_KmlLoaded;
  }

  // when the plugin is ready
  void geWebBrowser1_PluginReady(object sender, GEEventArgs e)
  {
    // tell the treeview which browser to work with
    this.kmlTreeView1.SetBrowserInstance(this.geWebBrowser1);
    
    // load some kml data
    geWebBrowser1.FetchKml("https://developers.google.com/kml/documentation/KML_Samples.kml");
    
  }
  
  // when kml has been loaded
  void geWebBrowser1_KmlLoaded(object sender, GEEventArgs e)
  {
    // load the kml data into the plug-in and treeview
    this.geWebBrowser1.ParseKmlObject(e.ApiObject);
    this.kmlTreeView1.ParseKmlObject(e.ApiObject);
  }
}
```

kmlTreeView1.setBrowserInstnc
# Details #

The KMLTreeViewcontrol inherits from the standard [System.Windows.Forms.TreeView](http://msdn.microsoft.com/en-us/library/system.web.ui.webcontrols.treeview.aspx) control class and has the same base members, methods, properties and events.

## Constructors ##

```

/// <summary>
/// Initializes a new instance of the KmlTreeView class.
/// </summary>
public KmlTreeView()

```

## Public methods ##

```
/// <summary>
/// Creates a KmlTreeViewNode from an KML feature 
/// </summary>
/// <param name="feature">The KML feature to base the node on</param>
/// <returns>A KmlTreeViewNode based on the feature</returns>
public static KmlTreeViewNode CreateNode(dynamic feature)

/// <summary>
/// Recursively parses a kml object into the tree
/// </summary>
/// <param name="kmlObject">The kml object to parse</param>
public void ParseKmlObject(dynamic kmlObject)

/// <summary>
/// Recursively parses a collection of kml objects into the tree
/// </summary>
/// <param name="kmlObjects">The kml objects to parse</param>
public void ParseKmlObject(dynamic[] kmlObjects)

/// <summary>
/// Set the browser instance for the control to work with
/// </summary>
/// <param name="browser">The GEWebBrowser instance</param>
public void SetBrowserInstance(GEWebBrowser browser)

/// <summary>
///  Returns the index of the first occurrence of a tree node with the specified key.
///  As the key is automatically set from the kmlObject id these should be unique.
/// </summary>
/// <param name="id">The object id</param>
/// <returns>The treenode that represents the object</returns>
public KmlTreeViewNode GetNodeByApiId(string id)
        
```

## Source ##

[KmlTreeView.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/KmlTreeView.cs)

[KmlTreeView.Designer.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/KmlTreeView.Designer.cs)

[KmlTreeViewresx](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/KmlTreeView.resx)

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;