&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;



# Introduction #

This method allows you to walk a Kml DOM and specify a callback function to be called on each node visited.

# Details #

The WalkKmlDom method optionally allows you to traverse Features and Geometries. This is useful when one wishes to calculate the view bounds of a model for example.

This method is based on the walkKmlDom function from the geojs javascript library:
http://code.google.com/p/earth-api-samples/source/browse/trunk/lib/kmldomwalk.js

## Method ##

```
/// <summary>
/// Based on kmldomwalk.js 
/// see: http://code.google.com/p/earth-api-samples/source/browse/trunk/lib/kmldomwalk.js
/// </summary>
/// <param name="kmlObject">The kml object to parse</param>
/// <param name="callBack">A delegate action, each node visited will be passed to this as the single parameter</param>
/// <param name="walkFeatures">Optionally walk features, defualt is true</param>
/// <param name="walkGeometries">Optionally walk geometries, default is false</param>
/// <remarks>This method is used by <see cref="KmlTreeView"/> to build the nodes</remarks>
/// <example>KmlHelpers.WalkKmlDom(kml, (Action dynamic)(x => { /* each x in the dom */}));</example>
public static void WalkKmlDom(
   dynamic kmlObject,
   Action<dynamic> callBack,
   bool walkFeatures = true,
   bool walkGeometries = false)
```

## Examples ##

This example uses the generic Action delegate to specify the callback functionality. Here the Google Earth Api method getType() is called on each node, feature and geometry object.

```
KmlHelpers.WalkKmlDom(kmlFeature,
      (Action<dynamic>)(eachNode =>
  {
      string type = eachNode.getType();
      MessageBox.Show(type);
  }),
  walkFeatures: true,
  walkGeometries: true);
}
```

This example shows the same functionality as the example above, this time however we are explicitly declaring a custom delegate method. Here only nodes and features are walked - as by default geometries are ignored.

```
Action<dynamic> Callback = eachNode => 
{ 
    string type = eachNode.getType();
    MessageBox.Show(type);
};

public void MyKmlWalk(dynamic kml)
{
    KmlHelpers.WalkKmlDom(kml, Callback);
}
```

## Remarks ##

This method is used by the Bounds class and the KmlTreeView class extensively.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;