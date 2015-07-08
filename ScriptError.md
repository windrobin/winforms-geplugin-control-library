

# Introduction #

This event is raised when there is an error in the hosted html document in the GEWebBrowser control

# Details #

The ScriptError event is useful for debugging the application you use the controls in.
You should use this event to determine when there is a script error and how to handle it based on the data in the GEEventArgs object.

The event only has any meaning once a host document has been loaded into the GEWebBrowser control.

## Syntax ##

```
public event EventHandler<GEEventArgs> ScriptError
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

            // when the plugin is ready
            geWebBrowser1.PluginReady += (o, e) =>
            {
                // ge can now be used exactly as it would be
                // in the native javascript api
                ge = e.ApiObject;
            };

            // handle any script errors
            this.geWebBrowser1.ScriptError += (o, e) =>
            {
                // show info about the error from the GEEventArgs object
                MessageBox.Show(e.Message, e.Data);
            };
        }
    }
}
```

## Remarks ##

It is worth noting that as well as "general errors", "custom script errors" can be raised by calling "application.SendError(type, message)" from the hosted document. The actual event logic for this "custom script error" process is handled via an instance of External class in the GEWebBrowser. "General errors" on the other hand are simply propagated from the native Document.Window.Error once a document has loaded in the GEWebBrowser.