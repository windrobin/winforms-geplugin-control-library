

# Introduction #

The SetBrowserInstance method is used to tell the various controls which instance of the [GEWebBrowser](GEWebBrowser.md) to work with. All the controls apart from the [GEWebBrowser](GEWebBrowser.md) support this method.

## Syntax ##

```
public void SetBrowserInstance(GEWebBrowser)    
```

## Examples ##

The basic method can be used by any of the controls like so:

```
kmlTreeView1.SetBrowserInstance(geWebBrowser1);
```

```
geStatusStrip1.SetBrowserInstance(geWebBrowser1);
```

```
geToolStrip1.SetBrowserInstance(geWebBrowser1);
```

To see how that works in practice please see the following example form.

```
namespace SimpleTest
{
    using System;
    using System.Windows.Forms;
    using FC.GEPluginCtrls;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            geWebBrowser1.LoadEmbededPlugin();
            geWebBrowser1.PluginReady += (o, e) =>
            {
                // Register the controls with the browser
                kmlTreeView1.SetBrowserInstance(geWebBrowser1);
                geStatusStrip1.SetBrowserInstance(geWebBrowser1);
                geToolStrip1.SetBrowserInstance(geWebBrowser1);
            };
        }
    }
}

```

## Remarks ##

Until SetBrowserInstance has been successfully called on a control, the control is disabled by default.