

# Introduction #

This method allows you to remove an event listener from the plug-in, it is basically a 'wrapper' function for the Google.Earth.removeEventListener method in the Api.

## Method ##

```
/// <summary>
/// Wrapper for the the google.earth.removeEventListener method
/// See: https://developers.google.com/earth/documentation/reference/google_earth_namespace#a4367d554eb492adcafa52925ddbf0c71
/// </summary>
/// <param name="feature">The target feature</param>
/// <param name="action">The event Id</param>
/// <param name="useCapture">Optional, use event capture</param>
public void RemoveEventListener(object feature, EventId action, bool useCapture = false)
```


## Examples ##

To removes an event listener previously added using GEWebBrower.AddEventListener from the event chain.

Note: You must pass in the exact same javascript function object, if any, as was passed to GEWebBrower.AddEventListener when removing.

```
namespace EventsTest
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
                ge = e.ApiObject;
                
                // add a click event listner to the globe
                geWebBrowser1.AddEventListener(ge.getGlobe(), EventId.Click);

                // add a view event to the view object
                geWebBrowser1.AddEventListener(ge.getView(), EventId.ViewChangeEnd);

                // add a plugin event 
                geWebBrowser1.AddEventListener(ge, EventId.BalloonClose);
            };
            
            geWebBrowser1.KmlEvent += (o, e) =>
            {
                // show the event data...
                MessageBox.Show(e.Data, e.Message); //KmlMouseEvent click
                MessageBox.Show(e.ApiObject.getTarget().getType()); // GEGlobe

                // remove the event
                geWebBrowser1.RemoveEventListener(ge.getGlobe(), EventId.Click);
            };

            geWebBrowser1.ViewEvent += (o, e) =>
            {
                 // remove the event
                geWebBrowser1.RemoveEventListener(ge.getView(), EventId.ViewChangeEnd);
            };

            geWebBrowser1.PluginEvent += (o, e) =>
            {
                // remove the event
                geWebBrowser1.RemoveEventListener(ge, EventId.BalloonClose);
            };
        }
    }
}

```

## Remarks ##

These functions allow you to easily handle any of the events in the Google Earth Plug-in Api in javascript or managed code.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;