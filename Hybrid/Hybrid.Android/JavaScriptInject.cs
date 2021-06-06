// <copyright file="JavaScriptInject.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Android.Content;
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
    public JavaScriptInject(Context context)
    {
      _context = context;
    }

    /// <summary>
    /// Annotate methods with the <see cref="JavascriptInterfaceAttribute"/> and the <see cref="ExportAttribute"/> to call them from JS.
    /// </summary>
    [JavascriptInterface]
    [Export("doSomething")]
    public void FromJavaScript()
    {
      Toast.MakeText(_context, "Hey from WebView", ToastLength.Short).Show();
    }

    /// <summary>
    /// Annotated methods can also accept parameters.
    /// </summary>
    [JavascriptInterface]
    [Export("doSomething")]
    public void FromJavaScript(string message)
    {
      Toast.MakeText(_context, message, ToastLength.Long).Show();
    }

    private readonly Context _context;
  }
}
