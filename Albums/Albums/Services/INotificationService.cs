// <copyright file="INotificationService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

namespace Albums.Services
{
  public interface INotificationService
  {
    void Show(string title, string description);

    void CreateNotificationChannel();
  }
}
