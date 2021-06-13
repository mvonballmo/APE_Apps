// <copyright file="IBiometricAuthenticationService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System;

namespace Albums.Services
{
  public interface IBiometricAuthenticationService
  {
    void Authenticate(Action success, Action<string> onError);
  }
}