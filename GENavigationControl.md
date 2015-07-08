

# Introduction #

This class provides a simple, managed, way to work with the plugin navigation controls.

# Details #

This wrapper class works by converting all the google earth plugin COM getter and setter methods to equivalent managed properties. For an example of this, please compare the standard Api methods for dealing with StreetViewEnabled against the manged properties which handle it.

javascript (public api)
```
// where 'ge' is a COM object (GEPlugin)
var controls = ge.getNavigationControl();
var streetViewEnabled = controls.getStreetViewEnabled();
controls.setStreetViewEnabled(1); 
```

c# (managed code)
```
// where 'ge' is a dynamic type wrapping the GEPlugin COM object 
GENavigationControl control = new GENavigationControl(ge);
bool streetViewEnabled = control.StreetViewEnabled;
control.StreetViewEnabled = true;
```

# Members #

## Constructor ##
```

/// <summary>
/// Initializes a new instance of the GEOptions class.
/// </summary>
/// <param name="gePlugin">GEPlugin COM object</param>
public GENavigationControl(dynamic gePlugin)

/// <summary>
/// Initializes a new instance of the GEOptions class.
/// </summary>
/// <param name="ge">GEPlugin COM object</param>
/// <param name="controlType">The control type. Defualt is NavigationControl.Large</param>
/// <param name="visiblity">The visiblity of the control. Defualt is Visiblity.Show</param>
/// <param name="streetViewEnabled">Optionally enables the streetview features. Default is false (off)</param>
public GENavigationControl(
    dynamic ge,
    NavigationControl controlType = NavigationControl.Large,
    Visiblity visiblity = Visiblity.Show,
    bool streetViewEnabled = false)

```

## Public Properties ##
```

/// <summary>
/// Gets or sets the navigaton control type
/// </summary>
public NavigationControl Type

/// <summary>
/// Gets or sets a value indicating if the street view functionality is enabled
/// </summary>
public bool StreetViewEnabled


/// <summary>
/// Gets or sets a value indicating whether the control is:
/// always visible, always hidden, or visible only when the user intends to use the control.
/// </summary>
public Visiblity Visiblity

```

## Source ##

http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/Wrappers/GENavigationControl.cs

## Remarks ##

This class is used by the [GEToolStrip](GEToolStrip.md) to toggle the navigation control.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;