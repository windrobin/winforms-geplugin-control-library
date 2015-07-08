

# Introduction #

This event is raised when the embedded Google Earth plugin plugin is ready.

# Details #

The PluginReady event is the basis for working with the plugin from managed code. In it allows you to safely use the plugin once it has initialized.

You should use this event to determine when the plugin is ready for you to use in your application.

This event is essentially just like the 'init callback' function one would use in JavaScript when using the createInstance method of the native Api.

## Syntax ##

```
public event EventHandler<GEEventArgs> PluginReady
```

## Examples ##

To use the event to work with the plugin take a look at the following simple form.

```
namespace PluginReadyTest
{
    using System;
    using System.Windows.Forms;
    using FC.GEPluginCtrls;

    public partial class Form1 : Form
    {
        private dynamic ge;

        public Form1()
        {
            InitializeComponent();

            geWebBrowser1.LoadEmbededPlugin();
            geWebBrowser1.PluginReady += (o, e) =>
            {
                // ge can now be used exactly as it would be
                // in the native javascript api
                ge = e.ApiObject;
            };
        }
    }
}
```

## Remarks ##

It is worth noting that the actual event logic is actually handled via an instance of External class and an active scripting method in the embedded page.

The GEWebBrowser simply echoes this "External event" to the application for simplicities sake.