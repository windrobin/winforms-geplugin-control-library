

# Introduction #

This class provides a simple, managed, way to set the various plug-in options.

# Details #

This wrapper class works by converting all the google earth plugin COM getter and setter methods to equivalent managed properties. For an example of this, please compare the standard Api methods for dealing with TerrainExaggeration against the manged properties which handle it.

**javascript**
```
// where 'ge' is a COM object (GEPlugin)
var terrainExaggeration = ge.getOptions().getTerrainExaggeration();
ge.getOptions().setTerrainExaggeration(2); 
```

**managed**
```
// where 'ge' is a dynamic type wrapping the GEPlugin COM object 
GEOptions options = new GEOptions(ge);
int terrainExaggeration = options.TerrainExaggeration;
options.TerrainExaggeration = 2;
```

# Members #

## Constructor ##

```
/// <summary>
/// Initializes a new instance of the GEOptions class.
/// </summary>
/// <param name="gePlugin">GEPlugin COM object</param>
public GEOptions(dynamic gePlugin)
```

## Public Properties ##

```
/// <summary>
/// Sets the map type (Earth or sky mode).
/// </summary>
/// <param name="type"></param>
public void setMapType(MapType type)
```

```
/// <summary>
/// Gets or sets the speed of zoom when user rolls the mouse wheel.
/// Default is 1. Set to a negative number to reverse the zoom direction.
/// </summary>
public double ScrollWheelZoomSpeed
```

```
/// <summary>
/// Gets or sets the speed at which the camera moves (0 to 5.0).
/// Set to SpeedTeleport to immediately appear at selected destination
/// </summary>
public double FlyToSpeed
```

```
/// <summary>
/// Gets or sets the visibliy of the status bar. 
/// Disabled by default.
/// </summary>
public bool StatusBarVisibility
```


```
/// <summary>
/// Gets or sets the visibliy of the grid. 
/// Disabled by default.
/// </summary>
public bool GridVisibility
```

```
/// <summary>
/// Gets or sets the visibliy of the overview map.
/// Disabled by default.
/// </summary>
public bool OverviewMapVisibility
```

```
/// <summary>
/// Gets or sets the visibliy of the scale legend. 
/// Disabled by default.
/// </summary>
public bool ScaleLegendVisibility
```

```
/// <summary>
/// Gets or sets the visibility of the 'blue atmosphere' that appears around the perimeter of the Earth.
/// Enabled by default
/// </summary>
public bool AtmosphereVisibility
```

```
/// <summary>
/// Gets or sets the ability of user panning and zooming of the map. Enabled by default.
/// </summary>
public bool MouseNavigationEnabled
```

```
/// <summary>
/// Gets or sets the animation of features as they are added or removed from the globe. 
/// Enabled by default
/// </summary>
public bool FadeInOutEnabled
```

```
/// <summary>
/// Gets or sets the unit of messurement for use in in the plug-in.
/// True if display units are set to imperial units (feet and miles).
/// False denotes metric units (meters and kilometers).
/// </summary>
public bool UnitsFeetMiles
```

```
/// <summary>
/// Gets or sets the status of the 'building selection' functionality.
/// When enabled, clicking a building will pop a feature balloon.
/// The information comes from the Google 3D Warehouse database.
/// Disabled by default.
/// </summary>
public bool BuildingSelectionEnabled
```

```
/// <summary>
/// Gets or sets the status of the 'building highlighting' functionality.
/// When enabled, buildings will be highlighted when they are moused over.
/// Disabled by default.
/// </summary>
public bool BuildingHighlightingEnabled
```

```
/// <summary>
/// Gets or sets the terrain exaggeration value.
/// Valid values are in the range of 1.0 through 3.0.
/// </summary>
public double TerrainExaggeration
```

```
/// <summary>
/// Gets or set the status of automatic 'ground level view' functionality.
/// When enabled, the view will change to 'ground level view' when the camera reaches ground level.
/// This view provides pan and lookAt controls, but no zoom slider. 
/// The tilt will be set to 90, or parallel with level ground.
/// Disabled by default.
/// </summary>
public bool AutoGroundLevelViewEnabled
```

## Source ##

[GEOptions.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/GEOptions.cs)

## Remarks ##

This class is used by the [GEToolStrip](GEToolStrip.md) to set the various plugin options.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;