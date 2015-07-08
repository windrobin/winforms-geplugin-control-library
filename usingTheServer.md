&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;

# Introduction #

You can use the inbuilt http server to work with local files such as kmz, kml, jpg, png, html, etc.

# Details #

This class provide a basic web server for the Plug-in to work with. A local server provides a way to circumvent all access issues between JavaScript and the local file system by serving the local files over a standard HTTP connection.

# Example #

This example presumes you have dragged a single instance a the GEWebBrowser control onto an empty form and that.

1) There is a directory named 'webroot' that is located in the root application directory.
2) Inside 'webroot' is a file named 'KML\_Samples.kml'.

```
namespace ServerTest
{
    using System;
    using System.Windows.Forms;
    using FC.GEPluginCtrls;
    using FC.GEPluginCtrls.HttpServer;

    public partial class Form1 : Form
    {
        // initialise the server and tell it where the
        // root directory is 
        private GEServer server = new GEServer("webroot");

        public Form1()
        {
            InitializeComponent();

            // the server is fully configurable...
            // server.RootDirectory = "/foo/bar/";
            // server.DefaultFileName = "bat.kml"
            // server.IPAddress = System.Net.IPAddress.Any;
            // server.Port = 80;

            // start the server
            server.Start();

            // load the plugin
            geWebBrowser1.LoadEmbededPlugin();

            // when the plug-in has loaded
            geWebBrowser1.PluginReady += (o, e) =>
            {
                // load the kml from the local server
                geWebBrowser1.FetchKml("http://localhost:8080/KML_Samples.kml");
            };

            geWebBrowser1.KmlLoaded += (o, e) =>
            {
                // add the kml to the plugin
                geWebBrowser1.ParseKmlObject(e.ApiObject);
            };
        }
    }
}

```