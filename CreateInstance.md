

# Introduction #

This is a wrapper method for the google.earth.createInstance function.

# Details #

Essesntially this method initializes the plug-in using a particular [ImageryBase](ImageryBase.md).

For more information on the google.earth.createInstance function please see: http://code.google.com/apis/earth/documentation/reference/google_earth_namespace.html#70288485024d8129dd1c290fb2e5553b

## Syntax ##

```
public void CreateInstance(ImageryBase database)
```


## Examples ##

This example shows how to load the moon, mars and earth imagery into the plug-in

```
geWebBrowser1.CreateInstance(ImageryBase.Moon);
```

```
geWebBrowser1.CreateInstance(ImageryBase.Mars);
```

```
geWebBrowser1.CreateInstance(ImageryBase.Earth);
```

To see how that works in practice please see the following example form.

```

using FC.GEPluginCtrls;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        
        // load the plugin 
        geWebBrowser1.LoadEmbededPlugin();

        // Set the imagery to the moon database 
        geWebBrowser1.CreateInstance(ImageryBase.Moon);
    }
}
```

## Remarks ##

This is basically the functionality used by the [GEToolStrip](GEToolStrip.md) imagery menu items.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;