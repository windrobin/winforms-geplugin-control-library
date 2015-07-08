

# Introduction #

As you can probably guess by the name, this method allows you to insert javascript into the loaded document at run-time.

## Syntax ##

```
public void InjectJavascript(
    string javascript
)
```

## Examples ##

This example inserts an active scripting function named 'jsExec' in to the head of the document loaded in geWebBrowser1

```
geWebBrowser1.InjectJavascript("function jsExec(s){window.execScript(s);}");
```

If you were to view the documents markup after the InjectJavascript function had run you would see the following

`<SCRIPT type="text/javascript">/* <![CDATA[ */ function jsExec(s){window.execScript(s);} /* ]]> */</SCRIPT>`

Likewise the following example injects the 'jsEval' function

```
geWebBrowser1.InjectJavascript("function jsEval(s){return eval(s);}");
```

Producing this markup

`<SCRIPT type="text/javascript">/* <![CDATA[ */ function jsEval(s){return eval(s);} /* ]]> */</SCRIPT>`


## Remarks ##

This method should only be used once a document has been loaded in the GEWebBrowser for it to have any meaning.

The overloaded 'partner' function InvokeJavascript can be used to call a javascript function once it has been injected.

&lt;wiki:gadget url="http://earthapi.googlepages.com/ad.xml" border="0" width="728" height="90" /&gt;