// <copyright file="JavaScriptInject.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Android.Webkit;
using Android.Widget;
using Java.Interop;
using Java.Lang;

namespace Hybrid.Droid
{
  /// <summary>
  /// JavaScript interface that is injected into the WebView.
  /// </summary>
  public class JavaScriptInject : Object
  {
    public JavaScriptInject(MainActivity mainActivity, WebView webView)
    {
      _mainActivity = mainActivity;
      _webView = webView;
    }

    /// <summary>
    /// Annotate methods with the <see cref="JavascriptInterfaceAttribute"/> and the <see cref="ExportAttribute"/> to call them from JS.
    /// </summary>
    [JavascriptInterface]
    [Export("doSomething")]
    public void FromJavaScript()
    {
      Toast.MakeText(_mainActivity, "Hey from WebView", ToastLength.Short).Show();

      _mainActivity.RunOnUiThread(() =>
      {
        // Evaluate JS in the browser.
        _webView.EvaluateJavascript("GetRandomNumber()", new Callback());
      });
    }

    /// <summary>
    /// Annotated methods can also accept parameters.
    /// </summary>
    [JavascriptInterface]
    [Export("doSomething")]
    public void FromJavaScript(string message)
    {
      Toast.MakeText(_mainActivity, message, ToastLength.Long).Show();
    }

    private readonly MainActivity _mainActivity;
    private readonly WebView _webView;
  }
}
