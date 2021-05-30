// <copyright file="MainActivity.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using Albums.Views;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Xamarin.Forms;

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
      Forms.Init(this, savedInstanceState);
      LoadApplication(new App());

      // Check if our notification was clicked while the app was closed.
      var extraValue = Intent.GetStringExtra(IntentExtraName);
      if (!string.IsNullOrEmpty(extraValue))
      {
        ShowNewAlbumPage();
      }
      else if (Intent.Extras?.Get("RemoteKey") != null)
      {
        ShowNewAlbumPage();
      }
    }

    protected override void OnNewIntent(Intent intent)
    {
      // Do something with the data you pass from the notification.
      var extraValue = intent.GetStringExtra(IntentExtraName);
      if (!string.IsNullOrEmpty(extraValue))
      {
        ShowNewAlbumPage();
      }

      base.OnNewIntent(intent);
    }

    private const string IntentExtraName = Albums.Droid.NotificationService.IntentExtraName;

    private void ShowNewAlbumPage()
    {
      RunOnUiThread(async () =>
      {
        // Add a wait to make sure our MainView is loaded up.
        await Task.Delay(200);

        // Navigate to the new-albums page
        await App.Services.GetInstance<Page>().Navigation.PushAsync(new NewAlbumPage());
      });
    }
  }
}