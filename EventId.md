

# Introduction #

Enumeration of the available event ids (actions) for the plug-in.

# Details #

This is essentially a managed version of the Google Earth Apis event ids.

# Members #

## mouse actions ##

```

/// <summary>
/// The click event id
/// </summary>
Click

/// <summary>
/// The double click event id
/// </summary>
DblClick

/// <summary>
/// The mouse over event id
/// </summary>
MouseOver

/// <summary>
/// The mouse down event id
/// </summary>
MouseDown

/// <summary>
/// The mouse up event id
/// </summary>
MouseUp

/// <summary>
/// The mouse out event id
/// </summary>
MouseOut

/// <summary>
/// The mouse move event id
/// </summary>
MouseMove

```

## plugin actions ##

```
/// <summary>
/// The frame end event id
/// </summary>
FrameEnd

/// <summary>
/// The balloon close event id
/// </summary>
BalloonClose

/// <summary>
/// The balloon opening event id
/// </summary>
BalloonOpening

```

## view actions ##

```

/// <summary>
/// The view change begin event id
/// </summary>
ViewChangeBegin

/// <summary>
/// The view change event id
/// </summary>
ViewChange

/// <summary>
/// The view change end event id
/// </summary>
ViewChangeEnd

```

# Source #

[EventId.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/Enumerations/EventId.cs)

# Remarks #

These are used when calling AddEventListener or [RemoveEventListener](AddEventListener.md) to signify the desired event id.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;