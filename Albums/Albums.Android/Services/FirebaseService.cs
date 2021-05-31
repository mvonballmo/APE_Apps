// <copyright file="FirebaseService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using Albums.Services;
using Android.App;
using Android.Content;
using Android.Util;
using Firebase.Messaging;
using Xamarin.Forms;

[assembly: Dependency(typeof(Albums.Droid.NotificationService))]

namespace Albums.Droid
{
  [Service]
  [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
  [IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
  public class FirebaseService : FirebaseMessagingService
  {
    public override void OnNewToken(string token)
    {
      Log.Debug(nameof(FirebaseService), "FCM token: " + token);

      DependencyService.Get<INotificationService>().CreateNotificationChannel();
    }

    public override void OnMessageReceived(RemoteMessage message)
    {
      Log.Debug(nameof(FirebaseService), $"Received message. {message}");

      DependencyService.Get<INotificationService>().Show(message.From, message.GetNotification().Body);
    }
  }
}