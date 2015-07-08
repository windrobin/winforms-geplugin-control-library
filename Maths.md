

# Introduction #

This static class provides some constants and basic geodesic functions for use with the Google Earth plugin.

# Details #

The various constants and methods in this class help when computing things like coordinates, bearings, distance and angles

Some of the functions are based on code in the javascript library geojs by Roman Nurik See http://code.google.com/p/geojs/

## Constants ##

```
/// <summary>
///  Earth’s mean radius in Kilometres
/// </summary>
public const double EarthMeanRadiusKilometres = 6371;
```

```
/// <summary>
///  Earth’s mean radius in miles
/// </summary>
public const double EarthMeanRadiusMiles = 3959;
```

```
/// <summary>
/// Miles To Kilometres Conversion ratio.
/// </summary>
/// <remarks>divide by to get miles to km, multiply to get km to miles</remarks>
public const double MilesToKilometresRatio = 0.621371192;
```

```
/// <summary>
/// Feet to Metres conversion ratio.
/// </summary>
public const double FeetToMetresRatio = 0.3048;
```


## Methods ##

```
/// <summary>
/// Get the final bearing from one Coordinate to another
/// </summary>
/// <param name="origin">the start Coordinate</param>
/// <param name="destination">the destination Coordinate</param>
/// <returns>The final bearing from start to destination</returns>
/// <remarks>See: http://williams.best.vwh.net/avform.htm for the original function </remarks>
public static double BearingFinal(Coordinate origin, Coordinate destination)
```


```
/// <summary>
/// Get the inital bearing from one location to another
/// </summary>
/// <param name="origin">the starting location</param>
/// <param name="destination">the destination location</param>>
/// <remarks>See: http://williams.best.vwh.net/avform.htm for the original function </remarks>
/// <returns>The inital bearing from origin to destination</returns>
public static double BearingInitial(Coordinate origin, Coordinate destination)
```


```
/// <summary>
/// Converts decimal degrees to radians
/// </summary>
/// <param name="degrees">value in degrees</param>
/// <returns>value in radians</returns>
public static double ConvertDegreesToRadians(double degrees)
```

```
/// <summary>
/// Converts radians to decimal degrees
/// </summary>
/// <param name="radians">value in radians</param>
/// <returns>value in degrees</returns>
public static double ConvertRadiansToDegrees(double radians)
```

```
/// <summary>
/// Converts a heading in the range [-180,180] to a bearing in the range [0,360] 
/// </summary>
/// <param name="heading">heading in the range [-180,180]</param>
/// <returns>bearing in the range [0,360]</returns>
public static double ConvertHeadingToBearing(double heading)
```


```
/// <summary>
/// Convert Kilometres To Miles 
/// </summary>
/// <param name="kilometres">distance in kilometrees</param>
/// <returns>distance in miles</returns>
public static double ConvertKilometresToMiles(double kilometres)
```


```
/// <summary>
/// Convert Miles To Kilometres
/// </summary>
/// <param name="miles">distance in miles</param>
/// <returns>distance in kilometrees</returns>
public static double ConvertMilesToKilometres(double miles)
```


```
/// <summary>
/// Destination point given distance and bearing from start point
/// </summary>
/// <param name="origin">the start point</param>
/// <param name="distance">the given distance in km or m</param>
/// <param name="bearing">the bearing in radians, clockwise from north</param>
/// <param name="units">The unit system to use, default is metric</param>
/// <returns>destination location as a Tuple(double lat, double lng)</returns>
public static Coordinate Destination(
Coordinate origin, 
double distance, 
double bearing, 
UnitSystem units = UnitSystem.Metric)
```


```
/// <summary>
/// Returns the distance in miles or kilometres of any two latitude / longitude points.
/// </summary>
/// <param name="origin">The start api object </param>
/// <param name="destination">The destination api object</param>
/// <param name="units">The unit system to use, default is metric</param>
/// <returns>Distance in kilometres</returns>
public static double DistanceCosine(dynamic origin, dynamic destination, UnitSystem units = UnitSystem.Metric)
```

```
/// <summary>
/// Returns the distance in miles or kilometres of any two latitude / longitude points.
/// </summary>
/// <param name="origin">The start latitude and longitude </param>
/// <param name="destination">The destination latitude and longitude </param>
/// <param name="units">The unit system to use, default is metric</param>
/// <returns>Distance in kilometres</returns>
public static double DistanceCosine(Coordinate origin, Coordinate destination, UnitSystem units = UnitSystem.Metric)
```


```
/// <summary>
/// Returns the distance in miles or kilometres of any two latitude / longitude points.
/// </summary>
/// <param name="origin">The start latitude and longitude </param>
/// <param name="destination">The destination latitude and longitude </param>
/// <param name="units">The unit system to use, default is metric</param>
/// <returns>Distance in kilometres</returns>
public static double DistanceHaversine(Coordinate origin, Coordinate destination, UnitSystem units = UnitSystem.Metric)
```


```
/// <summary>
/// Returns the distance in miles or kilometres of any two latitude / longitude points.
/// </summary>
/// <param name="origin">The start latitude and longitude </param>
/// <param name="destination">The destination latitude and longitude </param>
/// <param name="units">The unit system to use, default is metric</param>
/// <returns>Distance in kilometres</returns>
public static double DistanceHaversine(dynamic origin, dynamic destination, UnitSystem units = UnitSystem.Metric)
```

```
/// <summary>
/// Keep a number in the [0,PI] range
/// </summary>
/// <param name="radians">value in radians</param>
/// <returns>normalised angle in radians</returns>
public static double NormalizeAngle(double radians)
```


```
/// <summary>
///  Normalises a latitude to the [-90,90] range.
///  Latitudes above 90 or below -90 are constrained rather than wrapped.
/// </summary>
/// <param name="latitude">The latitude in degrees to normalize.</param>
/// <returns>Latitude within the [-90,90] range</returns>
public static double FixLatitude(double latitude)
```


```
/// <summary>
/// Normalises a longitude to the [-180,180] range.
/// Longitudes above 180 or below -180 are wrapped.
/// If the wrapped value is exactly equal to min or max, favors max, unless favorMin is true.
/// </summary>
/// <param name="longitude">The longitude in degrees to normalise</param>
/// <returns>Longitude within the [-180,180] range</returns>
public static double FixLongitude(double longitude)
```


```
/// <summary>
/// Reverses a number in the [0,PI] range
/// </summary>
/// <param name="radians">value in radians</param>
/// <returns>The oposite angle</returns>
public static double ReverseAngle(double radians)
```

```
/// <summary>
/// Wraps the given number to the given range.
/// If the wrapped value is exactly equal to min or max, favors max, unless favorMin is true.
/// </summary>
/// <param name="value">The value to wrap</param>
/// <param name="min">The minimum bound of the range</param>
/// <param name="max">The maximum bound of the range</param>
/// <param name="favorMin">Whether or not to favor min over max in the case of ambiguity. Default is false</param>
/// <returns>The value in the given range.</returns>
public static double WrapValue(double value, double min, double max, bool favorMin = false)
```

```
/// <summary>
/// Constrains the given number to the given range.
/// </summary>
/// <param name="value">The value to wrap</param>
/// <param name="min">The minimum bound of the range</param>
/// <param name="max">The maximum bound of the range</param>
/// <returns>The value constrained to the given range</returns>
public static double ConstrainValue(double value, double min, double max)
```

## Source ##

[Maths.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/Geo/Maths.cs)

## Remarks ##

This class is used by the Bounds, Coordinate and KmlHelpers classes.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;