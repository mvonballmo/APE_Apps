// <copyright file="IDialogService.cs" company="Marco von Ballmoos">
//   Copyright (c) 2021 Marco von Ballmoos. All rights reserved.
// </copyright>

using System.Threading.Tasks;

namespace Albums.Services
{
  public interface IDialogService
  {
    Task Show(string title, string message);

    Task<bool> Show(string title, string message, string positive, string negative);
  }
}
