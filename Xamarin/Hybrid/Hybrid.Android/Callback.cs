// <copyright file="Callback.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Android.Webkit;

namespace Hybrid.Droid
{
  // Sample callback which returns the result of EvaluateJavascript to the native part.
  public class Callback : Java.Lang.Object, IValueCallback
  {
    public void OnReceiveValue(Java.Lang.Object value)
    {
      // Do something with the value...
    }
  }
}