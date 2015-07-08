

# Introduction #

This struct provides a simple, managed, way to work with the kml color format.

# Details #

In kml color and opacity (alpha) values are expressed in hexadecimal notation. The range of values for any one color is 0 to 255 (00 to ff). For alpha, 00 is fully transparent and ff is fully opaque. The order of expression is aabbggrr, where aa=alpha (00 to ff); bb=blue (00 to ff); gg=green (00 to ff); rr=red (00 to ff).

This struct is essentially a managed version of the api's KmlColor object.

# Members #

## Constructors ##

```
/// <summary>
/// Initializes a new instance of the KmlColor struct.
/// </summary>
/// <param name="alpha">the alpha value, Default 255</param>
/// <param name="blue">the blue value, Default 255</param>
/// <param name="green">the green value, Default 255</param>
/// <param name="red">the red value, Default 255</param>
public KmlColor(byte alpha = 255, byte blue = 255, byte green = 255, byte red = 255)
```

```
/// <summary>
/// Initializes a new instance of the KmlColor struct from a system color and alpha value.
/// </summary>
/// <param name="color">the color to base the new kml color on</param>
/// <param name="alpha">Optional alpha value in the range [0-1].
/// Where 0 is fully transparant and 1 is fully opaque. Default value is 1</param>
public KmlColor(Color color, double alpha = 1.0)
```

```
/// <summary>
/// Initializes a new instance of the KmlColor struct from a color name and alpha value.
/// Named colors are listed here: http://msdn.microsoft.com/en-us/library/system.drawing.knowncolor.aspx
/// If the name parameter is not the valid name of a predefined color, the KmlColour defaults to black(0x000000)
/// </summary>
/// <param name="name">The name of the color</param>
/// <param name="alpha">Optional alpha value in the range [0-1].
/// Where 0 is fully transparant and 1 is fully opaque. Default value is 1</param>
public KmlColor(string name, double alpha = 1.0)
```

```
/// <summary>
/// Initializes a new instance of the KmlColor struct from an Api KmlColor object.
/// </summary>
/// <param name="colorObject">the api object to base the new color on</param>
public KmlColor(dynamic colorObject)
```

## Public Properties ##

```
/// <summary>
/// Gets or sets the Alpha (opacity) value 
/// </summary>
public byte Alpha 
```

```
/// <summary>
/// Gets or sets the Blue value 
/// </summary>
public byte Blue 
```

```
/// <summary>
/// Gets or sets the Green value 
/// </summary>
public byte Green 
```

```
/// <summary>
/// Gets or sets the Red value 
/// </summary>
public byte Red 
```


## Public Methods ##

```
/// <summary>
/// Overrides the ToString method
/// </summary>
/// <returns>The KmlColor object in the aabbggrr format</returns>
public override string ToString()
```

## Source ##

[KmlColor.cs](http://code.google.com/p/winforms-geplugin-control-library/source/browse/trunk/Wrappers/KmlColor.cs)

## Remarks ##

The KmlColor type is used by methods in the [KmlHelpers](KmlHelpers.md) and [GEHelpers](GEHelpers.md) classes. It is also worth noting that the methods ToKmlColor and ToKmlColorString in KmlHelpers (which both extend the System Color object) are useful when working with color in the api.

# Examples #

The following code

```

class ColorExample
{
    static void Main()
    {
        KmlColor[] colors = 
        {
          new KmlColor(),
          new KmlColor(255, 0, 0, 255),
          new KmlColor(System.Drawing.Color.Blue),
          new KmlColor(System.Drawing.Color.IndianRed, 0.5),
          new KmlColor("Control", 0.5),
          new KmlColor("Green", 0.2),
          new KmlColor("RoyalBlue")
        };

        foreach(KmlColor c in colors)
        {
          Console.WriteLine(c.ToString());
        }
    }
}
```


Would output

```
FFFFFFFF
FF0000FF
FFFF0000
7F5C5CCD
7FE2E2E2
33008000
FFE16941
```

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;