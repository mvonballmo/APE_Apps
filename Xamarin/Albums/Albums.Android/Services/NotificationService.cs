// <copyright file="NotificationService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.Services;
using Android.App;
using Android.Content;
using AndroidX.Core.App;
using Xamarin.Forms;

[assembly: Dependency(typeof(Albums.Droid.NotificationService))]

namespace Albums.Droid
{
  public class NotificationService : INotificationService
  {
    public const string IntentExtraName = "FromNotification";

    /// <inheritdoc/>
    public void Show(string title, string description)
    {
      // Build the notification with the details.
      var notification = CreateNotification(title, description);

      // Show the notification via the system notification manager.
      GetNotificationManager().Notify(NotificationId, notification);
    }

    public void CreateNotificationChannel()
    {
      GetNotificationManager().CreateNotificationChannel(CreateChannel());
    }

    private const string ChannelId = "AlbumChannel";
    private const string ChannelName = "Album Channel";
    private const string ChannelDescription = "Messages for the Album App";
    private const int NotificationId = 0;

    private static Notification CreateNotification(string title, string description)
    {
      // Retrieve an intent to launch our app.
      var launchIntent = GetLaunchIntent();

      // Add some extra (key/value) so we can handle it once the app starts.
      launchIntent.PutExtra(IntentExtraName, "foo");

      // Create a pending intent which wraps the given intent.
      var pendingIntent = CreatePendingIntent(launchIntent);

      var builder = new NotificationCompat.Builder(MainActivity.Activity, ChannelId)
        .SetContentTitle(title)
        .SetContentText(description)
        .SetContentIntent(pendingIntent)
        .SetSmallIcon(Resource.Drawable.ic_mtrl_chip_checked_circle)
        .SetAutoCancel(true);

      return builder.Build();
    }

    private static Intent GetLaunchIntent()
    {
      var result = MainActivity.Activity.PackageManager.GetLaunchIntentForPackage(MainActivity.Activity.PackageName);

      result.SetFlags(ActivityFlags.SingleTop);

      return result;
    }

    private static PendingIntent CreatePendingIntent(Intent notificationIntent)
    {
      return PendingIntent.GetActivity(MainActivity.Activity, 0, notificationIntent, PendingIntentFlags.UpdateCurrent);
    }

    private static NotificationChannel CreateChannel()
    {
      return new NotificationChannel(ChannelId, ChannelName, NotificationImportance.Default)
      {
        Description = ChannelDescription
      };
    }

    private static NotificationManager GetNotificationManager()
    {
      return (NotificationManager)MainActivity.Activity.GetSystemService(Context.NotificationService);
    }
  }
}