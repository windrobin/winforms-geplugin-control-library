&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;



![https://sites.google.com/site/earthapi2/GEToolStrip7.jpg](https://sites.google.com/site/earthapi2/GEToolStrip7.jpg)

# Introduction #

The GEToolStrip control integrates with the GEWebBrowser to provide controls for the basic options in the Google Earth Plug-in.

# Details #

The GEToolStrip inherits from the standard [System.Windows.Forms.ToolStrip](http://msdn.microsoft.com/en-us/library/system.windows.forms.toolstrip.aspx) control class

# Visual Designer #

These are the control options as they appear in the designer when using the control in Visual Studio.

![https://sites.google.com/site/earthapi2/GEToolStripProperties.jpg](https://sites.google.com/site/earthapi2/GEToolStripProperties.jpg)

# Members #

This is a complete list of all the custom GEToolStrip public members.
As noted the GEToolStrip inherits from the standard [System.Windows.Forms.ToolStrip](http://msdn.microsoft.com/en-us/library/system.windows.forms.toolstrip.aspx) control.

## Constructor ##

```
/// <summary>
/// Initializes a new instance of the GEToolStrip class.
/// </summary>
public GEToolStrip()
```

## Public Properties ##

```
/// <summary>
/// Gets or sets a value indicating whether the navigation items are visible
/// </summary>
public bool ShowNavigationItems

/// <summary>
/// Gets or sets a value indicating whether the Layers drop down is visible, default is true
/// </summary>
public bool ShowLayersDropDown

/// <summary>
/// Gets or sets a value indicating whether the Options drop down is visible, default is true
/// </summary>
public bool ShowOptionsDropDown

/// <summary>
/// Gets or sets a value indicating whether the View drop down is visible, default is true
/// </summary>
public bool ShowViewDropDown

/// <summary>
/// Gets or sets a value indicating whether the Imagery drop down is visible, default is true
/// </summary>
public bool ShowImageryDropDown

/// <summary>
/// Gets or sets a value indicating whether the screen grab button is visible, default is true
/// </summary>
public bool ShowScreenGrabButton

/// <summary>
/// Gets or sets a value indicating whether the view in maps button is visible
/// </summary>
public bool ShowViewInMapsButton

/// <summary>
/// Gets or sets a value indicating whether the language combobox is visible, default is true
/// </summary>
public bool ShowLanguageCombobox

/// <summary>
/// Gets or sets the AutoCompleteMode of the navigation textbox
/// Default is AutoCompleteMode.Append
/// </summary>
public AutoCompleteMode NavigationAutoCompleteMode
```

## Public methods ##

```
/// <summary>
/// Adds multiple entries to the Auto Compleate suggestion list
/// </summary>
/// <param name="suggestions">The suggestions to be entered</param>
/// <example>GEToolStrip.AddAutoCompleteSuggestions(new string[] { "London", "Paris", "Rome" });</example>
public void AddAutoCompleteSuggestions(string[] suggestions)

/// <summary>
/// Adds an entry to the Auto Compleate suggestion list
/// </summary>
/// <param name="suggestion">The suggestion entry</param>
/// <example>GEToolStrip.AddAutoCompleteSuggestions("London");</example>
public void AddAutoCompleteSuggestions(string suggestion)

/// <summary>
/// Removes all entries from the Auto Compleate suggestion list
/// </summary>
/// <example>GEToolStrip.ClearAutoCompleteSuggestions()</example>
public void ClearAutoCompleteSuggestions()

/// <summary>
/// Set the browser instance for the control to work with
/// </summary>
/// <param name="browser">The GEWebBrowser instance</param>
/// <example>GEToolStrip.SetBrowserInstance(GEWebBrowser)</example>
public void SetBrowserInstance(GEWebBrowser browser)
```

## Source ##

[GEToolStrip.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/GEToolStrip.cs)

[GEToolStrip.Designer.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/GEToolStrip.Designer.cs)

[GEToolStrip.resx](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/GEToolStrip.resx)

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;