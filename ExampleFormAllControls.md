&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;

# Introduction #

This form shows the most basic set up of the GEWebBrowser along with all the other controls.

# Details #

Here the plugin behaves exactly as it would with the default set-up in a web page. You can use the mouse and keys to navigate when the control has focus.

The ApiObject member of GEEventArgs returned in the PluginReady event is the GEPlugin object. This allows one to work seemlessly with the Google Earth Api - just as if you were programming in the native JavaScript.

The GEPlugin object is also available outside the PluginReady event from the [GEWebBrowser's Plugin property](http://code.google.com/p/winforms-geplugin-control-library/wiki/GEWebBrowser#Public_Properties).

Although working in with in the native JavaScript is possible, it is worth noting that the other controls ([GEStatusStrip](GEStatusStrip.md), [GEToolStrip](GEToolStrip.md), [KmlTreeView](KmlTreeView.md)) and the other helper classes ([GEHelpers](GEHelpers.md), [KmlHelpers](KmlHelpers.md), [GEOptions](GEOptions.md), etc) offer a much cleaner, safer and managed way to work with the Api.

```

namespace SimpleControlsTest
{
    using System;
    using System.Windows.Forms;
    using FC.GEPluginCtrls;

    public partial class Form1 : Form
    {
        ////dynamic ge = null;

        public Form1()
        {
            InitializeComponent();

            geWebBrowser1.LoadEmbededPlugin();
            geWebBrowser1.PluginReady += (o, e) =>
            {
                ////ge = e.ApiObject;

                // Register the controls with the browser
                kmlTreeView1.SetBrowserInstance(geWebBrowser1);
                geStatusStrip1.SetBrowserInstance(geWebBrowser1);
                geToolStrip1.SetBrowserInstance(geWebBrowser1);
            };
        }
    }
}

```