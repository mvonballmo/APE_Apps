using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Albums;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
}

public class NotificationService : INotificationService
{
  private const string ChannelId = "Channel ID";
  private const string ChannelName = "TODO Channel";
  private const string ChannelDescription = "Messages for the TODO App";

  public void CreateNotificationChannel()
  {
    var channel = new NotificationChannel(ChannelId, ChannelName, NotificationImportance.Default)
    {
      Description = ChannelDescription
    };

    var notificationManager = (NotificationManager)MainActivity.Activity.GetSystemService(Context.NotificationService);
    notificationManager.CreateNotificationChannel(channel);
  }
}
