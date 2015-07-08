&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;



![http://earthapi.googlepages.com/GEStatusStrip.jpg](http://earthapi.googlepages.com/GEStatusStrip.jpg)

# Introduction #

The GEStatusStrip control intergrates with the GEWebBrowser to provide useful data such as the api, plugin and browser versions as well as data streaming information.


# Details #

This control allows you to get visual feedback from the Google Earth Plugin Api.

The progress bar on the left hand side of the control polls the plug-in using the native Apis getStreamingPercent() method to display the  current streaming status of the plug-in.

The various labels on the right hand side of the control show the current Internet Explorer, Google Earth Api and Google Earth Plugin versions.

The GEToolStrip inherits from the standard [System.Windows.Forms.StatusStrip](http://msdn.microsoft.com/en-us/library/system.windows.forms.statusstrip.aspx) control class

# Members #

This is a compleate list of the GEStatusStrip custom members. As noted the The GEToolStrip inherits from the standard [System.Windows.Forms.StatusStrip](http://msdn.microsoft.com/en-us/library/system.windows.forms.statusstrip.aspx) control.

## Constructor ##

```
/// <summary>
/// Initializes a new instance of the GEStatusStrip class.
/// </summary>
public GEStatusStrip()
```

## Public Properties ##

```
/// <summary>
/// Gets or sets the timer interval for polling data
/// Default is 100ms
/// </summary>
public int Interval

/// <summary>
/// Gets or sets a value indicating whether the progress bar is visible
/// Default is true
/// </summary>
public bool ShowStreamingProgressBar

/// <summary>
/// Gets or sets a value indicating whether the streaming label is visible
/// Default is true
/// </summary>
public bool ShowStreamingStatusLabel

/// <summary>
/// Gets or sets a value indicating whether the browser version label is visible
/// Default is true
/// </summary>
public bool ShowBrowserVersionStatusLabel

/// <summary>
/// Gets or sets a value indicating whether the api version label is visible
/// Default is true
/// </summary>
public bool ShowApiVersionStatusLabel

/// <summary>
/// Gets or sets a value indicating whether the plug-in version label is visible
/// Default is true
/// </summary>
public bool ShowPluginVersionStatusLabel
```

## Public methods ##

```
/// <summary>
/// Set the browser instance for the control to work with
/// </summary>
/// <param name="browser">The GEWebBrowser instance</param>
/// <example>GEToolStrip.SetBrowserInstance(GEWebBrowser)</example>
public void SetBrowserInstance(GEWebBrowser browser)
```

## Source ##

[GEToolStrip.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/GEStatusStrip.cs)

[GEStatusStrip.Designer.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/GEStatusStrip.Designer.cs)

[GEStatusStrip.resx](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/GEStatusStrip.resx)

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;