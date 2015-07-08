

# Introduction #

Enumeration of the available altitude modes for the plug-in.

# Details #

This is essentially a managed version of the Google Earth Apis KmlAltitudeModeEnum

See: http://code.google.com/apis/earth/documentation/reference/interface_g_e_plugin.html

# Members #

```
/// <summary>
/// Specifies that altitudes are at ground level.
/// For Ground overlays, this means that the image will be draped over the terrain.
/// </summary>
ClampToGround

/// <summary>
/// Specifies that altitudes are to be interpreted as meters above or below ground level.
/// (i.e. the elevation of the terrain at the location).
/// </summary>
RelativeToGround

/// <summary>
/// Specifies that altitudes are to be interpreted as meters above or below sea level,
/// regardless of the actual elevation of the terrain beneath the object.
/// For example, if you set the altitude of an object to 10 meters with an absolute altitude mode,
/// the object will appear to be at ground level if the terrain beneath is also 10 meters above sea level.
/// If the terrain is 3 meters above sea level, the object will appear elevated above the terrain by 7 meters.
/// If, on the other hand, the terrain is 15 meters above sea level, the object may be completely invisible.
/// </summary>
Absolute

/// <summary>
/// Specifies that altitudes are at sea floor level.
/// </summary>
ClampToSeaFloor

/// <summary>
/// Specifies that altitudes are to be interpreted as meters above sea floor.
/// (i.e. the elevation of the sea floor at the location).
/// </summary>
RelativeToSeaFloor

/// <summary>
/// Specifies that no altitude is to be interpreted
/// </summary>
None

```

# Source #

[AltitudeMode.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/Enumerations/AltitudeMode.cs)

# Remarks #

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;