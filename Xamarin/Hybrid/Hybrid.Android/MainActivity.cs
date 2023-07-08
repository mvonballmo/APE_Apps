// <copyright file="MainActivity.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Webkit;

namespace Hybrid.Droid
{
  [Activity(Label = "Hybrid", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
  public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
      LoadApplication(new App());

      // Set the content layout which contains a simple web view.
      SetContentView(Resource.Layout.activity_main);

      // Extract the web view from the layout.
      var webView = (WebView)FindViewById(Resource.Id.webView);

      // Configure WebView to allow JS and inject our custom interface.
      webView.Settings.JavaScriptEnabled = true;
      webView.AddJavascriptInterface(new JavaScriptInject(this, webView), "Native");

      // Load a local HTML file.
      webView.LoadUrl("file:///android_asset/index.html");
    }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }
  }
}