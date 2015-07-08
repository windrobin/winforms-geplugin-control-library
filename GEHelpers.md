

# Introduction #

This class provides some basic Google Earth plugin helpers functions.

# Details #

This works with Interfaces whose names begin with GE in the api. These  Interfaces allow for programmatic access to core plugin functionality and other miscellaneous options.

For an example of this, please compare the standard Api methods for dealing with enabling a layer against the manged method and types which handle it.

**javascript**
```
// where 'ge' is a COM object (GEPlugin)
ge.getLayerRoot().enableLayerById(ge.LAYER_BUILDINGS, true);
```

**managed**
```
// where 'ge' is a dynamic type wrapping the GEPlugin COM object 
GEHelpers.EnableLayer(ge, Layer.Buildings, true);
```

Some of the code is based on the "GEHelpers javasctipt library" by Roman Nurik. http://earth-api-samples.googlecode.com/svn/trunk/lib/geplugin-helpers.js


## Methods ##


```
/// <summary>
/// This is a simple "ge.getFeatures().appendChild(kml)" wrapper
/// </summary>
/// <param name="ge">the plugin instance to add the features to</param>
/// <param name="kml">the features to add</param>
/// <exception cref="System.ArgumentException" >Throws an exception if ge is not an instance of GEPlugin.</exception>
public static void AddFeaturesToPlugin(dynamic ge, dynamic kml)
```

```
/// <summary>
/// Enables or disables a plugin layer - wrapper for ge.getLayerRoot().enableLayerById()
/// </summary>
/// <param name="ge">The plugin instance</param>
/// <param name="layer">The id of the layer to work with</param>
/// <param name="value">True turns the layer on, false off</param>
public static void EnableLayer(dynamic ge, Layer layer, bool value)
```

```
/// <summary>
/// Get an element by ID - wrapper for ge.getElementById()
/// </summary>
/// <param name="ge">The plugin instance</param>
/// <param name="id">The id feature to find</param>
/// <returns>The feature specified by the ID parameter if it exists</returns>
public static dynamic GetElementById(dynamic ge, string id)
```

```
/// <summary>
/// Attempts to set the view of the plugin to the given api object 
/// </summary>
/// <param name="ge">the plugin</param>
/// <param name="feature">the api object</param>
/// <param name="boundsFallback">Optionally set whether to fallback to the bounds method</param>
/// <param name="aspectRatio">Optional aspect ratio</param>
/// <param name="defaultRange">Optional default range</param>
/// <param name="scaleRange">Optional scale range</param>
public static void FlyToObject(
dynamic ge,
dynamic feature,
bool boundsFallback = true,
double aspectRatio = 1.0,
double defaultRange = 1000,
double scaleRange = 1.5)
```

```
/// <summary>
/// Gets the Kml of all the features in the plug-in
/// </summary>
/// <param name="ge">The plugin</param>
/// <returns>String of all the Kml from the plugin - or an empty string</returns>
public static string GetAllFeaturesKml(dynamic ge)
```

```
/// <summary>
/// Get the current pluin view as a point object
/// </summary>
/// <param name="ge">the plugin</param>
/// <returns>Point set to the current view (or false)</returns>
public static dynamic GetCurrentViewAsPoint(dynamic ge)
```

```
/// <summary>
/// Depreciated: now the dynamic type is used and getType can be called directly.
/// Gets the type of an active scripting object from a generic runtime callable wrapper.
/// This method attempts to invoke the member 'getType' on the given object.
/// </summary>
/// <param name="wrapper">The com object wrapper</param>
/// <returns>The name of the type, or an empty string on failure</returns>
public static string GetTypeFromWrapper(object wrapper)
```

```
/// <summary>
/// Gets the ApiType of a given <paramref name="feature">feature</paramref>
/// </summary>
/// <param name="feature">The feature to get the type of</param>
/// <returns>
/// The type of the <paramref name="feature">feature</paramref> or 'ApiType.None'.
/// </returns>
public static ApiType GetApiType(dynamic feature)
```

```
/// <summary>
/// Checks if the given object in an RCW is of the type GEPlugin
/// </summary>
/// <param name="feature">The object to check</param>
/// <returns>true if the object is of the type GEPlugin </returns>
public static bool IsGE(dynamic feature)
```

```
/// <summary>
/// Checks if a given <paramref name="feature">feature</paramref>
/// is of a given type <paramref name="type">type</paramref>
/// </summary>
/// <param name="feature">The feature to test</param>
/// <param name="type">The type to check</param>
/// <returns>
/// True if the <paramref name="feature">feature</paramref>
/// is the given <paramref name="type">type</paramref>
/// </returns>
public static bool IsApiType(dynamic feature, ApiType type)
```

```
/// <summary>
/// Checks if a given string <paramref name="input"/> is a valid url
/// of the given <paramref name="kind"/>
/// </summary>
/// <param name="input">the string to check</param>
/// <param name="kind">the kind of uri to check for</param>
/// <returns>true if the string is a uri</returns>
public static bool IsUri(string input, UriKind kind)
```

```
/// <summary>
/// Opens the balloon for the given feature in the plugin using OpenFeatureBalloon()
/// </summary>
/// <param name="ge">the plugin instance</param>
/// <param name="feature">the feature to open a balloon for</param>
/// <param name="useUnsafeHtml">Optional setting to use getBalloonHtmlUnsafe, default is false</param>
/// <param name="minWidth">Optional minimum balloon width, default is 100</param>
/// <param name="minHeight">Optional minimum balloon height, default is 100</param>
/// <param name="maxWidth">Optional maximum balloon width, default is 800</param>
/// <param name="maxHeight">Optional maximum balloon height, default is 600</param>
/// <param name="setBalloon">Optionally set the balloon to be the current in the plugin</param>
/// <param name="closeButtonEnabled">Optionally display a closed button on the balloon, default is true</param>
/// <param name="backgroundColor">Optionally set the balloon backgroundColor in the #rrggbb format, default #FFFFFF</param>
/// <param name="foregroundColor">Optionally set the balloon backgroundColor in the #rrggbb format, default #000000</param>
/// <returns>The feature balloon or null</returns>
public static dynamic OpenFeatureBalloon(
dynamic ge,
dynamic feature,
bool useUnsafeHtml = false,
int minWidth = 100,
int minHeight = 100,
int maxWidth = 800,
int maxHeight = 600,
bool setBalloon = true,
bool closeButtonEnabled = true,
string backgroundColor = "#FFFFFF",
string foregroundColor = "#000000")
```

```
/// <summary>
/// Remove all features from the plugin 
/// </summary>
/// <param name="ge">The plugin instance</param>
public static void RemoveAllFeatures(dynamic ge)
```

```
/// <summary>
/// Remove a feature from the plug-in based on the feature ID
/// </summary>
/// <param name="ge">The plugin instance</param>
/// <param name="id">The id of the feature to remove</param>
public static void RemoveFeatureById(dynamic ge, string id)
```

```
/// <summary>
/// Remove a features from the plug-in based on the feature IDs
/// </summary>
/// <param name="ge">The plugin instance</param>
/// <param name="ids">The ids of the features to remove</param>
public static void RemoveFeatureById(dynamic ge, string[] ids)
```

```
/// <summary>
/// Displays the current plugin view in Google Maps using the default system browser
/// </summary>
/// <param name="ge">The plugin instance</param>
public static void ShowCurrentViewInMaps(dynamic ge)
```

```
/// <summary>
/// Toggles any 'media player' associated with a particular Kml type represented by a treenode.
/// So far this includes KmlTours (GETourPlayer) and KmlPhotoOverlays (GEPhotoOverlayViewer)
/// </summary>
/// <param name="ge">The plugin instance</param>
/// <param name="feature">The feature to check</param>
/// <param name="visible">Vaule indicating whether the player should be visible or not.</param>
public static void ToggleMediaPlayer(dynamic ge, dynamic feature, bool visible = true)
```

## Source ##

[GEHelpers.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/Helpers/GEHelpers.cs)

## Remarks ##

This class is used throughout the control library.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;