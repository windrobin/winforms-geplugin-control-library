&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;

# Introduction #

This form shows the most basic set up of the [GEWebBrowser](GEWebBrowser.md), there are no other controls added.

# Details #

Here the plugin behaves exactly as it would with the default set-up in a web page. You can use the mouse and keys to navigate when the control has focus.

The dynamic type returned by the PluginReady event allows one to work seemlessly with the GEPlugin object, just as if you were programming in the native javaScript API.

The GEPlugin object is also available outside the PluginReady event from the GEWebBrowser's Plugin property.

However, it is worth noting that the other controls ([GEStatusStrip](GEStatusStrip.md), [GEToolStrip](GEToolStrip.md), [KmlTreeView](KmlTreeView.md)) and the other helper classes ([GEHelpers](GEHelpers.md), [KmlHelpers](KmlHelpers.md), [GEOptions](GEOptions.md), etc) in this library offer much cleaner, safer, managed, ways to work with the Api.

# Example #

This example presumes you have dragged a single instance a the GEWebBrowser control onto an empty form. Here the only two events we wire up are PluginReady and ScriptError. The ScriptError is not necessary, although it can help with debugging any errors if you alter the host JavaScript for example.

```

namespace ExampleFormTest
{
    using System;
    using System.Windows.Forms;
    using FC.GEPluginCtrls;

    public partial class Form1 : Form
    {
        // a simple dynamic type to hold
        // the GEPlugin object
        private dynamic ge;

        public Form1()
        {
            InitializeComponent();

            geWebBrowser1.LoadEmbededPlugin();
           
            // Handle the he PluginReady event 
            geWebBrowser1.PluginReady += (o, e) =>
            {
                ge = e.ApiObject;

                // Here you can now use 'ge' exactly as you would
                // in the native javascript api. Whenever you make a 
                // call to an api member, you should check for any RuntimeBinderExceptions
                try
                {
                  var type = ge.getType();
                  var version = ge.getPluginVersion();
                  MessageBox.Show(type, version);
                }
                catch(RuntimeBinderException)
                {
                  // there was an error calling either
                  // getType or getPluginVersion...
                }
            };

            // handle any script errors
            this.geWebBrowser1.ScriptError += (o, e) =>
            {
                MessageBox.Show(e.Message, e.Data);
            };
        }
    }
}

```

When the following code is run the earth loads and is then the information is displayed, for example.

![https://sites.google.com/site/earthapi2/simpleform.jpg](https://sites.google.com/site/earthapi2/simpleform.jpg)