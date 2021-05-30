// <copyright file="MainActivity.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;

namespace Albums.Droid
{
  [Activity(Label = "Albums", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
  public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
  {
    public MainActivity()
    {
      Activity = this;
    }

    public static Activity Activity { get; private set; }

    public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
    {
      Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

      base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
    }

    protected override void OnCreate(Bundle savedInstanceState)
    {
      base.OnCreate(savedInstanceState);

      Xamarin.Essentials.Platform.Init(this, savedInstanceState);
      Xamarin.Forms.Forms.Init(this, savedInstanceState);
      LoadApplication(new App());
    }
  }
}