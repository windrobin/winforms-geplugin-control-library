

# Introduction #

This method allows you to add an event listener to the plug-in, it is basically a 'wrapper' function for the Google.Earth.addEventListener method in the Api.

## Method ##

```
/// <summary>
/// Wrapper for the the google.earth.addEventListener method
/// </summary>
/// <param name="feature">The target feature</param>
/// <param name="action">The event Id</param>
/// <param name="javascript">The name of javascript callback function to use, or an anonymous function</param>
/// <param name="useCapture">Optionally use event capture</param>
/// <example>GEWebBrowser.AddEventListener(object, "click", "someFunction");</example>
/// <example>GEWebBrowser.AddEventListener(object, "click", "function(event){alert(event.getType);}");</example>
public void AddEventListener(dynamic feature, EventId action, string javascript = null, bool useCapture = false)
```


## Examples ##

To use an event listener with the built in callback functions simply register the KmlEvent listener then add the events you wish. It is worth noting that KmlLoaded and ViewEvent's have their own in-built delegates. The following example shows how to use the in-bult events to handle kml and view events.

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

Another way to use your own callback functions in managed code is to extend the External class. This allows you to register your own COM visible methods and to pass event objects to them from the plug-in. The following example shows how to register a custom external class and how to use a method of the class as an event handler.

```
namespace TestApplication
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;
    using FC.GEPluginCtrls;

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.geWebBrowser1.ObjectForScripting = new MyExternal(geWebBrowser1);
            this.geWebBrowser1.LoadEmbeddedPlugin();
        }
    }

    [ComVisibleAttribute(true)]
    public class MyExternal : External
    {
        GEWebBrowser browser = null;
        dynamic pm1 = null;

        public MyExternal(GEWebBrowser browser)
            : base()
        {
            this.browser = browser;

            this.PluginReady += (o, e) =>
            {
                //create a placemark
                pm1 = KmlHelpers.CreatePlacemark(e.ApiObject, "pm1", 52, 0);

                // add the event listener to the placemark.
                // notice the callback parameter, it is an anonymous javascript function
                // that calls 'SomeMethod' with an argument 'hello'
                this.browser.AddEventListener(pm1, EventId.Click, "function(e){application.SomeMethod(e);}");
            };
        }

        /// <summary>
        /// SomeMethod, called when the placemark is clicked
        /// </summary>
        /// <param name="e">event data</param>
        public void SomeMethod(dynamic e)
        {
            // you can use native api calls on the object 
            string type = e.getType(); // KmlMouseEvent
            string targetType = e.getTarget().getType(); // KmlPlacemark
            MessageBox.Show(type, targetType);

            // Remove the event, notice we don't need to supply the custom 
            // script argument. The internal event logic does that for you.
            this.browser.RemoveEventListener(pm1, EventId.Click);
        }
    }
}
```


## Remarks ##

These functions allow you to easily handle any of the events in the Google Earth Plug-in Api in javascript or managed code.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;