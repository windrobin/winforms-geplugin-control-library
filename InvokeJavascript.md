

# Introduction #

Invokes/executes a javascript function defined in the current document

## Overload List ##

```
public object InvokeJavascript(string)
```

```
public object InvokeJavascript(string, object[])
```

## Examples ##

Imagine we have the following javascript functions defined in the current document

```
function hi(){
  alert('hello world'};
}

function myAdd(arg1,arg2) {
  alert(ar1+arg2);
}

function myDiv(arg1, arg2) {
  return arg1/arg2;
}
```

We can use InvokeJavascript to call the 'hi' function like so

```
geWebBrowser1.InvokeJavascript("hi");
```

Which would cause the GEWebBrowser to alert 'hello world'

We can use the overloaded InvokeJavascript function to call the 'myAdd' function and pass arguments to it like so

```
geWebBrowser1.InvokeJavascript("myAdd", new object[] { 5, 2 });
```

Which would cause the GEWebBrowser to alert '7'

The object returned by InvokeJavascript is the same object returned by the Active Scripting call. So we can do the following.

```
double divided = (double)geWebBrowser1.InvokeJavascript("myDiv", new object[] { 5, 2 });
MessageBox.Show(divided.toString());
```

Which would display a message box showing '2.5'

## Remarks ##

These functions, along with the partner function InjectJavascript, allow you to run any javascript you may require without having to amend the hosted HTML document.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;