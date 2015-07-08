

# Introduction #

This class provides a simple, managed, way to work with the plugin tour player control.

# Details #

This wrapper class works by converting all the google earth plugin COM getter and setter methods to equivalent managed properties. For an example of this, please compare the standard Api methods for dealing with CurrentTime against the manged properties which handle it.

javascript (public api)
```
// where 'ge' is a COM object (GEPlugin)
var tourplayer = ge.getTourPlayer();
var currentTime = tourplayer.getCurrentTime();
tourplayer.setCurrentTime(99);
```

c# (managed code)
```
// where 'ge' is a dynamic type wrapping the GEPlugin COM object 
GETourPlayer tourplayer = new GETourPlayer(ge);
double currentTime = tourplayer.CurrentTime;
tourplayer.CurrentTime = 99;
```

# Members #

## Constructor ##

```
/// <summary>
/// Initializes a new instance of the GETourPlayer class.
/// </summary>
/// <param name="ge">the plugin object</param>
public GETourPlayer(dynamic ge)
```

## Public Properties ##

```
/// <summary>
/// Gets or sets a value indicating the current elapsed playing time of the active tour, in seconds.
/// </summary>
public double CurrentTime


/// <summary>
/// Gets the total duration of the active tour, in seconds.
/// If no tour is loaded, the behaviour of this method is undefined.
/// </summary>
public double Duration
```

## Public Methods ##

```
/// <summary>
/// Pauses the currently active tour.
/// </summary>
public void Pause()

/// <summary>
/// Plays the currently active tour.
/// </summary>
public void Play()

/// <summary>
/// Resets the currently active tour, stopping playback and rewinding to the start of the tour.
/// </summary>
public void Reset()

/// <summary>
/// Enters the given tour object, exiting any other currently active tour.
/// This method does not automatically begin playing the tour.
/// If the argument is null, then any currently active tour is exited and normal globe navigation is enabled.
/// </summary>
/// <param name="tour">A tour object (KmlTour)</param>
public void SetTour(dynamic tour)
```

## Source ##

http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/Wrappers/GETourPlayer.cs

## Remarks ##

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;