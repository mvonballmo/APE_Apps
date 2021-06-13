// <copyright file="BiometricAuthenticationService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;
using Albums.Droid;
using Android.Content;
using Android.Hardware.Biometrics;
using Android.OS;
using Android.Runtime;
using Java.Lang;
using Xamarin.Forms;

[assembly: Dependency(typeof(Albums.Services.BiometricAuthenticationService))]

namespace Albums.Services
{
  public class BiometricAuthenticationService : IBiometricAuthenticationService
  {
    public void Authenticate(Action success, Action<string> onError)
    {
      var builder = new BiometricPrompt.Builder(MainActivity.Activity)
        .SetDescription("Authenticate with Biometrics!")
        .SetTitle("TODO BIO")
        .SetNegativeButton("Cancel", MainActivity.Activity.MainExecutor, new CancelClickListener())
        .Build();

      builder.Authenticate(new CancellationSignal(), MainActivity.Activity.MainExecutor, new BiometricAuthenticationCallback(success, onError));
    }

    private class CancelClickListener : Java.Lang.Object, IDialogInterfaceOnClickListener
    {
      public void OnClick(IDialogInterface dialog, int which)
      {
        // NOP
      }
    }

    private class BiometricAuthenticationCallback : BiometricPrompt.AuthenticationCallback
    {
      public BiometricAuthenticationCallback(Action callback, Action<string> onError)
      {
        _callback = callback;
        _onError = onError;
      }

      public override void OnAuthenticationSucceeded(BiometricPrompt.AuthenticationResult result)
      {
        _callback();
      }

      public override void OnAuthenticationFailed()
      {
        // NOP
      }

      public override void OnAuthenticationError([GeneratedEnum] BiometricErrorCode errorCode, ICharSequence errString)
      {
        _onError(errString.ToString());
      }

      private readonly Action _callback;
      private readonly Action<string> _onError;
    }
  }
}
